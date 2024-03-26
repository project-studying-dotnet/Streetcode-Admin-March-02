namespace Streetcode.XUnitTest.MediatRTests.StreetCodeTests.Text.GetById
{
    using System;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Streetcode.TextContent;
    using Streetcode.BLL.MediatR.Streetcode.Text.GetById;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    public class GetTextByIdHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        public GetTextByIdHandlerTest()
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
        public async Task Result_GetTextById_Test()
        {
            var handler = new GetTextByIdHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            var result = await handler.Handle(new GetTextByIdQuery(2), CancellationToken.None);

            result.Value.Should().NotBeNull();
        }
    }
}