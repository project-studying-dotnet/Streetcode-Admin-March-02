namespace Streetcode.XUnitTest.MediatRTests.StreetCodeTests.Streetcodee.GetShortById
{
    using System;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Dto.Streetcode;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Streetcode;
    using Streetcode.BLL.MediatR.Streetcode.Streetcode.GetShortById;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    public class GetStreetcodeShortByIdHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        public GetStreetcodeShortByIdHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetAllStreetcodes();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<StreetcodeProfile>();
            });

            this.mapper = mapperConfig.CreateMapper();

            this.mockLogger = new Mock<ILoggerService>();
        }

        [Fact]
        public async Task Result_GetStreetcodeShortById_Test()
        {
            var handler = new GetStreetcodeShortByIdHandler(this.mapper, this.mockRepository.Object, this.mockLogger.Object);

            var result = await handler.Handle(new GetStreetcodeShortByIdQuery(1), CancellationToken.None);

            result.Value.Should().Be(typeof(StreetcodeShortDto));
        }
    }
}