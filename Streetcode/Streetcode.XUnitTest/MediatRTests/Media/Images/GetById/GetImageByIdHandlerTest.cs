// <copyright file="GetImageByIdHandlerTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Streetcode.XUnitTest.MediatRTests.Media.Images.GetById
{
    using System.Threading.Tasks;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Interfaces.BlobStorage;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Media.Images;
    using Streetcode.BLL.MediatR.Media.Image.GetById;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    /// <summary>
    /// Can not test.
    /// </summary>
    public class GetImageByIdHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;
        private readonly Mock<IBlobService> mockBlob;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetImageByIdHandlerTest"/> class.
        /// </summary>
        public GetImageByIdHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetImagesRepositoryMock();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<ImageProfile>();
            });

            this.mapper = mapperConfig.CreateMapper();

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
            var handler = new GetImageByIdHandler(this.mockRepository.Object, this.mapper, this.mockBlob.Object, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetImageByIdQuery(1), CancellationToken.None);

            // Assert
            result.Value.Should().NotBeNull();
        }

        /// <summary>
        /// Get by id first item mime type should be "First mime type".
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetByIdFirstShouldBeFirstTest()
        {
            // Arrange
            var handler = new GetImageByIdHandler(this.mockRepository.Object, this.mapper, this.mockBlob.Object, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetImageByIdQuery(1), CancellationToken.None);

            // Assert
            result.Value.MimeType.Should().Be("First image mime type");
        }

        /// <summary>
        /// Get by id second item should not be fourth item.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetByIdSecondShouldNotBeFourthTest()
        {
            // Arrange
            var handler = new GetImageByIdHandler(this.mockRepository.Object, this.mapper, this.mockBlob.Object, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetImageByIdQuery(2), CancellationToken.None);

            // Assert
            result.Value.MimeType.Should().NotBe("Fourth image mime type");
        }
    }
}
