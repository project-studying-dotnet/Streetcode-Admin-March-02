namespace Streetcode.XUnitTest.MediatRTests.StreetCodeTests.RelatedTerm.Delete
{
    using System;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Streetcode.TextContent;
    using Streetcode.BLL.MediatR.Streetcode.RelatedTerm.Delete;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    public class DeleteRelatedTermHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        public DeleteRelatedTermHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetAllRelatedTerms();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<RelatedTermProfile>();
            });

            this.mapper = mapperConfig.CreateMapper();

            this.mockLogger = new Mock<ILoggerService>();
        }

        [Fact]
        public async Task Result_ShouldNotBeNull_Test()
        {
            var handler = new DeleteRelatedTermHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            var result = await handler.Handle(new DeleteRelatedTermCommand("1Word"), CancellationToken.None);

            result.Value.Should().NotBeNull();
        }
    }
}