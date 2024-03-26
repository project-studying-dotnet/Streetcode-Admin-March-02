namespace Streetcode.XUnitTest.MediatRTests.StreetCodeTests.RelatedFigure
{
    using System;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.MediatR.Streetcode.RelatedFigure.Delete;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    public class DeleteRelatedFigureHandlerTest
    {
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        public DeleteRelatedFigureHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetAllRelatedFigures();

            this.mockLogger = new Mock<ILoggerService>();
        }

        [Fact]
        public async Task Result_ShouldNotBeNull_Test()
        {
            var handler = new DeleteRelatedFigureHandler(this.mockRepository.Object, this.mockLogger.Object);

            var result = await handler.Handle(new DeleteRelatedFigureCommand(1, 1), CancellationToken.None);

            result.Value.Should().NotBeNull();
        }
    }
}