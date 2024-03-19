// <copyright file="DeleteImageHandlerTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Streetcode.XUnitTest.MediatRTests.Media.Images.Delete
{
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Interfaces.BlobStorage;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.MediatR.Media.Image.Delete;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    /// <summary>
    /// Can not test.
    /// </summary>
    public class DeleteImageHandlerTest
    {
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;
        private readonly Mock<IBlobService> mockBlob;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteImageHandlerTest"/> class.
        /// </summary>
        public DeleteImageHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetImagesRepositoryMock();

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
            var handler = new DeleteImageHandler(this.mockRepository.Object, this.mockBlob.Object, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new DeleteImageCommand(1), CancellationToken.None);

            // Assert
            result.Value.Should().NotBeNull();
        }
    }
}
