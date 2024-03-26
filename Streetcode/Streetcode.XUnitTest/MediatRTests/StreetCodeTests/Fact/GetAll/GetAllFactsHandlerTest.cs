namespace Streetcode.XUnitTest.MediatRTests.StreetCodeTests.Fact.GetAll
{
    using System;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Streetcode.TextContent;
    using Streetcode.BLL.MediatR.Streetcode.Fact.GetAll;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    public class GetAllFactsHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        public GetAllFactsHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetAllFacts();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<FactProfile>();
            });

            this.mapper = mapperConfig.CreateMapper();

            this.mockLogger = new Mock<ILoggerService>();
        }

        [Fact]
        public async Task Result_GetAllFacts_Test()
        {
            var handler = new GetAllFactsHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            var result = await handler.Handle(new GetAllFactsQuery(), CancellationToken.None);

            result.Value.Should().NotBeNullOrEmpty();
        }
    }
}