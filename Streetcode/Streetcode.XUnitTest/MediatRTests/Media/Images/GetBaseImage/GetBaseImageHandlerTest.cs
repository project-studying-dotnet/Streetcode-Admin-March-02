// <copyright file="GetBaseImageHandlerTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Streetcode.XUnitTest.MediatRTests.Media.Images.GetBaseImage
{
    using System.Threading.Tasks;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Dto.Media.Images;
    using Streetcode.BLL.Interfaces.BlobStorage;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.MediatR.Media.Image.GetBaseImage;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    /// <summary>
    /// Can not test.
    /// </summary>
    public class GetBaseImageHandlerTest
    {
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;
        private readonly Mock<IBlobService> mockBlob;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetBaseImageHandlerTest"/> class.
        /// </summary>
        public GetBaseImageHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetImagesRepositoryMock();

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
            var handler = new GetBaseImageHandler(this.mockBlob.Object, this.mockRepository.Object, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetBaseImageQuery(1), CancellationToken.None);

            // Assert
            result.Value.Should().NotBeNull();
        }    
    }
}
