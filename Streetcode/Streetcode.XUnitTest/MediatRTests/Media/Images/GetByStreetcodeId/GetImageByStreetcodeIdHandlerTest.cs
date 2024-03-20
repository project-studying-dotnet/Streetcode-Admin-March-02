namespace Streetcode.XUnitTest.MediatRTests.Media.Images.GetByStreetcodeId
{
    using System.Threading.Tasks;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Interfaces.BlobStorage;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Media.Images;
    using Streetcode.BLL.MediatR.Media.Audio.GetByStreetcodeId;
    using Streetcode.BLL.MediatR.Media.Image.GetByStreetcodeId;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    /// <summary>
    /// 
    /// </summary>
    public class GetImageByStreetcodeIdHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;
        private readonly Mock<IBlobService> mockBlob;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetImageByStreetcodeIdHandlerTest"/> class.
        /// </summary>
        public GetImageByStreetcodeIdHandlerTest()
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
            var handler = new GetImageByStreetcodeIdHandler(this.mockRepository.Object, this.mapper, this.mockBlob.Object, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetImageByStreetcodeIdQuery(1), CancellationToken.None);

            // Assert
            result.Value.Should().NotBeNull();
        }

        /// <summary>
        /// Get by id second item blob name should be second blob name.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetByIdSecondBlobNameShouldBeSecond()
        {
            // Arrange
            var handler = new GetImageByStreetcodeIdHandler(this.mockRepository.Object, this.mapper, this.mockBlob.Object, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetImageByStreetcodeIdQuery(1), CancellationToken.None);

            // Assert
            result.Value.ElementAt(1).BlobName.Should().Be("Second image blob name");
        }
    }
}
