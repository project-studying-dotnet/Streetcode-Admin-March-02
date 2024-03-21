// <copyright file="GetBaseAudioHandlerTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Streetcode.XUnitTest.MediatRTests.Media.Audio.GetBaseAudio
{
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Interfaces.BlobStorage;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.MediatR.Media.Audio.GetBaseAudio;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    /// <summary>
    /// CAN NOT TEST
    /// BLL -> MediatR -> Media -> Audio -> GetBaseAudio
    /// </summary>
    public class GetBaseAudioHandlerTest
    {
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;
        private readonly Mock<IBlobService> mockBlob;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetBaseAudioHandlerTest"/> class.
        /// </summary>
        public GetBaseAudioHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetAudiosRepositoryMock();

            this.mockLogger = new Mock<ILoggerService>();

            this.mockBlob = new Mock<IBlobService>();
        }

        /// <summary>
        /// Get by id not null test.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetByIdNotNullTest()
        {
            // Arrange
            var handler = new GetBaseAudioHandler(this.mockBlob.Object, this.mockRepository.Object, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetBaseAudioQuery(1), CancellationToken.None);

            // Assert
            result.Value.Should().NotBeNull();
        }
    }
}
