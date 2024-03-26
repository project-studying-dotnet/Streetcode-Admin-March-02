namespace Streetcode.XUnitTest.MediatRTests.StreetCodeTests.Streetcodee.GetAllShort
{
    using System;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Streetcode;
    using Streetcode.BLL.MediatR.Streetcode.Streetcode.GetAllShort;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    public class GetAllStreetcodesShortHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        public GetAllStreetcodesShortHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetStreetcodeRepositoryMock();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<StreetcodeProfile>();
            });

            this.mapper = mapperConfig.CreateMapper();

            this.mockLogger = new Mock<ILoggerService>();
        }

        [Fact]
        public async Task Result_GetAllStreetcodesShort_Test()
        {
            var handler = new GetAllStreetcodesShortHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            var result = await handler.Handle(new GetAllStreetcodesShortQuery(), CancellationToken.None);

            result.Value.Should().NotBeNull();
        }
    }
}