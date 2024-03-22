// <copyright file="CreateImageHandlerTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Streetcode.XUnitTest.MediatRTests.Media.Images.Create
{
    using System.Threading.Tasks;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Dto.Media.Images;
    using Streetcode.BLL.Interfaces.BlobStorage;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Media.Images;
    using Streetcode.BLL.MediatR.Media.Image.Create;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    /// <summary>
    /// Can not test.
    /// </summary>
    public class CreateImageHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;
        private readonly Mock<IBlobService> mockBlob;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateImageHandlerTest"/> class.
        /// </summary>
        public CreateImageHandlerTest()
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
        /// Create not null and should be created test.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task CreateNotNullAudioMustBeCreated()
        {
            // Arrange
            var handler = new CreateImageHandler(this.mockBlob.Object, this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(
                new CreateImageCommand(new ImageFileBaseCreateDto()
                {
                    Alt = "Created image",
                    Title = "Created title",
                    Extension = ".txt",
                    BaseFormat = "Created base",
                    MimeType = "Created mime type",
                }), CancellationToken.None);

            // Assert
            result.Value.Should().NotBeNull();
        }
    }
}
