namespace Streetcode.XUnitTest.MediatRTests.StreetCodeTests.Term.GetAll
{
    using System;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Streetcode.TextContent;
    using Streetcode.BLL.MediatR.Streetcode.Term.GetAll;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    public class GetAllTermsHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        public GetAllTermsHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetAllTerms();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<TermProfile>();
            });

            this.mapper = mapperConfig.CreateMapper();

            this.mockLogger = new Mock<ILoggerService>();
        }

        [Fact]
        public async Task Result_GetAllTerms_Test()
        {
            var handler = new GetAllTermsHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            var result = await handler.Handle(new GetAllTermsQuery(), CancellationToken.None);

            result.Value.Count().Should().Be(3);
        }
    }
}