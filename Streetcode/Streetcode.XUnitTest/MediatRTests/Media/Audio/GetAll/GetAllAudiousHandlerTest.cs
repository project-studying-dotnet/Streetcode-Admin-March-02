namespace Streetcode.XUnitTest.MediatRTests.Media.Audio.GetAll
{
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.DTO.Media.Audio;
    using Streetcode.BLL.Interfaces.BlobStorage;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Media;
    using Streetcode.BLL.MediatR.Media.Audio.GetAll;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    /// <summary>
    /// TESTED SUCCESSFULLY
    /// BLL -> MediatR -> Media -> Audio -> GetAll.
    /// </summary>
    public class GetAllAudiousHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;
        private readonly Mock<IBlobService> mockBlob;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllAudiousHandlerTest"/> class.
        /// </summary>
        public GetAllAudiousHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetAudiosRepositoryMock();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<AudioProfile>();
            });

            this.mapper = mapperConfig.CreateMapper();

            this.mockLogger = new Mock<ILoggerService>();

            this.mockBlob = new Mock<IBlobService>();
        }

        /// <summary>
        /// Get all not null or empty test.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetAllNotNullOrEmptyTest()
        {
            // Arrange
            var handler = new GetAllAudiosHandler(this.mockRepository.Object, this.mapper, this.mockBlob.Object, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetAllAudiosQuery(), CancellationToken.None);

            // Assert
            result.Value.Should().NotBeNullOrEmpty();
        }

        /// <summary>
        /// Get all list count shoul be four.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetAllCountShouldBeFour()
        {
            // Arrange
            var handler = new GetAllAudiosHandler(this.mockRepository.Object, this.mapper, this.mockBlob.Object, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetAllAudiosQuery(), CancellationToken.None);

            // Assert
            result.Value.Count().Should().Be(4);
        }

        /// <summary>
        /// Get all list should be type AudioDTO.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetAllShouldBeTypeListAudioDTO()
        {
            // Arrange
            var handler = new GetAllAudiosHandler(this.mockRepository.Object, this.mapper, this.mockBlob.Object, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetAllAudiosQuery(), CancellationToken.None);

            // Assert
            result.Value.Should().BeOfType<List<AudioDTO>>();
        }
    }
}
