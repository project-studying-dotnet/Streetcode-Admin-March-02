﻿// <copyright file="GetAudioByStreetcodeIdHandlerTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Streetcode.XUnitTest.MediatRTests.Media.Audio.GetByStreetcodeId
{
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Interfaces.BlobStorage;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Media;
    using Streetcode.BLL.MediatR.Media.Audio.GetByStreetcodeId;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    /// <summary>
    ///  Can not test.
    /// </summary>
    public class GetAudioByStreetcodeIdHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;
        private readonly Mock<IBlobService> mockBlob;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAudioByStreetcodeIdHandlerTest"/> class.
        /// </summary>
        public GetAudioByStreetcodeIdHandlerTest()
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
        /// Get by id not null test.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetByIdNotNullTest()
        {
            // Arrange
            var handler = new GetAudioByStreetcodeIdQueryHandler(this.mockRepository.Object, this.mapper, this.mockBlob.Object, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetAudioByStreetcodeIdQuery(1), CancellationToken.None);

            // Assert
            result.Value.Should().NotBeNull();
        }

        /// <summary>
        /// Get by id second item description length should not be zero.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetByIdSecondLengthShouldNotBeZero()
        {
            // Arrange
            var handler = new GetAudioByStreetcodeIdQueryHandler(this.mockRepository.Object, this.mapper, this.mockBlob.Object, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetAudioByStreetcodeIdQuery(1), CancellationToken.None);

            // Assert
            result.Value.Description?.Length.Should().NotBe(0);
        }
    }
}
