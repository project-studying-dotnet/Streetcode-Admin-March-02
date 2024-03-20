// <copyright file="GetVideoByStreetcodeIdVideoHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Streetcode.XUnitTest.MediatRTests.Media.Video.GetByStreetcodeId
{
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Media;
    using Streetcode.BLL.MediatR.Media.Video.GetByStreetcodeId;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    /// <summary>
    ///  Will be test in future.
    /// </summary>
    public class GetVideoByStreetcodeIdVIdeoHandler
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetVideoByStreetcodeIdVIdeoHandler"/> class.
        /// </summary>
        public GetVideoByStreetcodeIdVIdeoHandler()
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
        /// Get by id not null test.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetByIdNotNullTest()
        {
            // Arrange
            var handler = new GetVideoByStreetcodeIdHandler(this.mockRepository.Object, this.mapper,  this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetVideoByStreetcodeIdQuery(1), CancellationToken.None);

            // Assert
            result.Value.Id.Should().NotBe(null);
        }
    }
}
