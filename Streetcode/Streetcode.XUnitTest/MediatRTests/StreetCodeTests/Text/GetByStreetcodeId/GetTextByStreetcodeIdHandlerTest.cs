using System;
using AutoMapper;
using FluentAssertions;
using Moq;
using Streetcode.BLL.Interfaces.Logging;
using Streetcode.BLL.Interfaces.Text;
using Streetcode.BLL.Mapping.Streetcode.TextContent;
using Streetcode.BLL.MediatR.Streetcode.Text.GetById;
using Streetcode.BLL.MediatR.Streetcode.Text.GetByStreetcodeId;
using Streetcode.DAL.Repositories.Interfaces.Base;
using Streetcode.XUnitTest.MediatRTests.Mocks;
using Xunit;

namespace Streetcode.XUnitTest.MediatRTests.StreetCodeTests.Text.GetByStreetcodeId
{
    public class GetTextByStreetcodeIdHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;
        private readonly ITextService textService;

        public GetTextByStreetcodeIdHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetAllTexts();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<TextProfile>();
            });

            this.mapper = mapperConfig.CreateMapper();

            this.mockLogger = new Mock<ILoggerService>();
        }

        [Fact]
        public async Task Result_GetTextByStreetCodeId_Test()
        {
            var handler = new GetTextByStreetcodeIdHandler(this.mockRepository.Object, this.mapper, this.textService, this.mockLogger.Object);

            var result = await handler.Handle(new GetTextByStreetcodeIdQuery(2), CancellationToken.None);

            result.Value.Id.Should().Be(2);
        }
    }
}
