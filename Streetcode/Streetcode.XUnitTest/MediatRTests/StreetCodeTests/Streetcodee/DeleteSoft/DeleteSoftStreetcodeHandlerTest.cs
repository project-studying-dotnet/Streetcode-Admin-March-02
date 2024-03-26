namespace Streetcode.XUnitTest.MediatRTests.StreetCodeTests.Streetcodee.DeleteSoft
{
    using System;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.MediatR.Streetcode.Streetcode.DeleteSoft;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    public class DeleteSoftStreetcodeHandlerTest
    {
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        public DeleteSoftStreetcodeHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetAllStreetcodes();

            this.mockLogger = new Mock<ILoggerService>();
        }

        [Fact]
        public async Task Result_ShouldNotBeNull_Test()
        {
            var handler = new DeleteSoftStreetcodeHandler(this.mockRepository.Object, this.mockLogger.Object);

            var result = await handler.Handle(new DeleteSoftStreetcodeCommand(1), CancellationToken.None);

            result.Value.Should().NotBeNull();
        }
    }
}