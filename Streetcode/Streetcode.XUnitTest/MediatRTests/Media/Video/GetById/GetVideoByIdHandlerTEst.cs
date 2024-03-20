﻿// <copyright file="GetVideoByIdHandlerTEst.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Streetcode.XUnitTest.MediatRTests.Media.Video.GetById
{
    using System.Threading.Tasks;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Media;
    using Streetcode.BLL.MediatR.Media.Audio.GetById;
    using Streetcode.BLL.MediatR.Media.Video.GetById;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    /// <summary>
    /// TESTED SUCCESSFULLY.
    /// </summary>
    public class GetVideoByIdHandlerTEst
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;


        /// <summary>
        /// Initializes a new instance of the <see cref="GetVideoByIdHandlerTEst"/> class.
        /// </summary>
        public GetVideoByIdHandlerTEst()
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
            var handler = new GetVideoByIdHandler(this.mockRepository.Object, this.mapper,  this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetVideoByIdQuery(2), CancellationToken.None);

            // Assert
            result.Value.Should().NotBeNull();
        }

        /// <summary>
        /// Get by id first item description should be "Second video description".
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetByIdFirstShouldBeFirstTest()
        {
            // Arrange
            var handler = new GetVideoByIdHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetVideoByIdQuery(1), CancellationToken.None);

            // Assert
            result.Value.Description.Should().Be("First video description");
        }

        /// <summary>
        /// Get by id second item should not be fourth item.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetByIdSecondShouldNotBeFourthTest()
        {
            // Arrange
            var handler = new GetVideoByIdHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetVideoByIdQuery(2), CancellationToken.None);

            // Assert
            result.Value.Description.Should().NotBe("Fourth video description");
        }
    }
}
