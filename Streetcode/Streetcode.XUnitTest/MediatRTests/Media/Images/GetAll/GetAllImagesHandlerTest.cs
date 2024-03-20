// <copyright file="GetAllImagesHandlerTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Streetcode.XUnitTest.MediatRTests.Media.Images
{
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.DTO.Media.Audio;
    using Streetcode.BLL.DTO.Media.Images;
    using Streetcode.BLL.Interfaces.BlobStorage;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.MediatR.Media.Audio.GetAll;
    using Streetcode.BLL.MediatR.Media.Image.GetAll;
    using Streetcode.DAL.Entities.Media.Images;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    /// <summary>
    /// TESTED SUCCESSFULLY.
    /// </summary>
    public class GetAllImagesHandlerTest
    {
        private readonly Mock<IRepositoryWrapper>? mockRepository;
        private readonly Mock<IMapper>? mockMapper;
        private readonly Mock<IBlobService>? mockBlobService;
        private readonly Mock<ILoggerService>? mockLogger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllImagesHandlerTest"/> class.
        /// </summary>
        public GetAllImagesHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetImagesRepositoryMock();
            this.mockMapper = new Mock<IMapper>();
            this.mockBlobService = new Mock<IBlobService>();
            this.mockLogger = new Mock<ILoggerService>();

            this.ConfigureMapper(this.GetImagesDTOList());
        }

        /// <summary>
        /// Get all not null or empty test.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetAllNotNullOrEmptyTest()
        {
            // Arrange
            var handler = new GetAllImagesHandler(this.mockRepository.Object, this.mockMapper.Object, this.mockBlobService.Object, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetAllImagesQuery(), CancellationToken.None);

            // Assert
            result.Value.Should().NotBeNullOrEmpty();
        }

        /// <summary>
        /// Get all list count should be two.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetAllCountShouldBeTwo()
        {
            // Arrange
            var handler = new GetAllImagesHandler(this.mockRepository.Object, this.mockMapper.Object, this.mockBlobService.Object, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetAllImagesQuery(), CancellationToken.None);

            // Assert
            result.Value.Count().Should().Be(2);
        }

        /// <summary>
        /// Get all list should be type AudioDTO.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetAllShouldBeTypeListAudioDTO()
        {
            // Arrange
            var handler = new GetAllImagesHandler(this.mockRepository.Object, this.mockMapper.Object, this.mockBlobService.Object, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetAllImagesQuery(), CancellationToken.None);

            // Assert
            result.Value.Should().BeOfType<List<ImageDTO>>();
        }

        private List<ImageDTO> GetImagesDTOList()
        {
            return new List<ImageDTO>()
            {
                new ImageDTO
                {
                    Id = 1,
                },
                new ImageDTO
                {
                    Id = 2,
                },
            };
        }

        private void ConfigureMapper(List<ImageDTO> imageListDTO)
        {
            this.mockMapper?.Setup(x => x.Map<IEnumerable<ImageDTO>>(It.IsAny<IEnumerable<object>>()))
            .Returns(imageListDTO);
        }
    }
}