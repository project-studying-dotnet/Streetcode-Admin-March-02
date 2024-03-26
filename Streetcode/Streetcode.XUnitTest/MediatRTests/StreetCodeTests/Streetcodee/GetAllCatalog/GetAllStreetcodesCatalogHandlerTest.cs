namespace Streetcode.XUnitTest.MediatRTests.StreetCodeTests.Streetcodee.GetAllCatalog
{
    using System;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Streetcode;
    using Streetcode.BLL.MediatR.Streetcode.Streetcode.GetAllCatalog;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    public class GetAllStreetcodesCatalogHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        public GetAllStreetcodesCatalogHandlerTest()
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
        public async Task Result_GetAllStreetcodesCatalog_Test()
        {
            var handler = new GetAllStreetcodesCatalogHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            var result = await handler.Handle(new GetAllStreetcodesCatalogQuery(1, 10), CancellationToken.None);

            result.Value.Should().NotBeNull();
        }
    }
}