namespace Streetcode.XUnitTest.MediatRTests.StreetCodeTests.Term.GetById
{
    using System;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Streetcode.TextContent;
    using Streetcode.BLL.MediatR.Streetcode.Term.GetById;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    public class GetTermByIdHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        public GetTermByIdHandlerTest()
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
        public async Task Result_GettermById_Test()
        {
            var handler = new GetTermByIdHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            var result = await handler.Handle(new GetTermByIdQuery(2), CancellationToken.None);

            result.Value.Id.Should().Be(2);
        }
    }
}