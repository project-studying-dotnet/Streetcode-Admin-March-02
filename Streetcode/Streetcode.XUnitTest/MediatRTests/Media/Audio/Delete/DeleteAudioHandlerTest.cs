// <copyright file="DeleteAudioHandlerTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Streetcode.XUnitTest.MediatRTests.Media.Audio.Delete
{
    using System.Threading.Tasks;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Interfaces.BlobStorage;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.MediatR.Media.Audio.Delete;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    /// <summary>
    /// CAN NOT TEST.
    /// </summary>
    public class DeleteAudioHandlerTest
    {
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;
        private readonly Mock<IBlobService> mockBlob;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteAudioHandlerTest"/> class.
        /// </summary>
        public DeleteAudioHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetAudiosRepositoryMock();

            this.mockLogger = new Mock<ILoggerService>();

            this.mockBlob = new Mock<IBlobService>();
        }

        /// <summary>
        /// Delete item with first id result should not be null test.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteWithFirstIdShouldNotBeNull()
        {
            // Arrange
            var handler = new DeleteAudioHandler(this.mockRepository.Object, this.mockBlob.Object, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new DeleteAudioCommand(1), CancellationToken.None);

            // Assert
            result.Value.Should().NotBeNull();
        }
    }
}
