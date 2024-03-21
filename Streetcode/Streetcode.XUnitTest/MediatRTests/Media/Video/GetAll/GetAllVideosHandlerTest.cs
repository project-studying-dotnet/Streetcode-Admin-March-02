// <copyright file="GetAllVideosHandlerTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Streetcode.XUnitTest.MediatRTests.Media.Video.GetAll
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.DTO.Media.Video;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Media;
    using Streetcode.BLL.MediatR.Media.Video.GetAll;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    /// <summary>
    /// TESTED SUCCESSFULLY.
    /// </summary>
    public class GetAllVideosHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;


        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllVideosHandlerTest"/> class.
        /// </summary>
        public GetAllVideosHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetVideosRepositoryMock();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<VideoProfile>();
            });

            this.mapper = mapperConfig.CreateMapper();

            this.mockLogger = new Mock<ILoggerService>();
        }

        /// <summary>
        /// Get all not null or empty test.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetAllNotNullOrEmptyTest()
        {
            // Arrange
            var handler = new GetAllVideosHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetAllVideosQuery(), CancellationToken.None);

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
            var handler = new GetAllVideosHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetAllVideosQuery(), CancellationToken.None);

            // Assert
            result.Value.Count().Should().Be(4);
        }

        /// <summary>
        /// Get all list should be type VideoDTO.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetAllShouldBeTypeListAudioDTO()
        {
            // Arrange
            var handler = new GetAllVideosHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetAllVideosQuery(), CancellationToken.None);

            // Assert
            result.Value.Should().BeOfType<List<VideoDTO>>();
        }
    }
}
