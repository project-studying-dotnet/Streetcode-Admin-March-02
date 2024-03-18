// <copyright file="GetArtByIdHandlerTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Streetcode.XUnitTest.MediatRTests.Media.Art.GetById
{
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Media.Images;
    using Streetcode.BLL.MediatR.Media.Art.GetById;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    /// <summary>
    /// TESTED SUCCESSFULLY
    /// BLL -> MediatR -> Media -> Art -> GetById.
    /// </summary>
    public class GetArtByIdHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetArtByIdHandlerTest"/> class.
        /// </summary>
        public GetArtByIdHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetArtRepositoryMock();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<ArtProfile>();
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
            var handler = new GetArtByIdHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetArtByIdQuery(1), CancellationToken.None);

            // Assert
            result.Value.Should().NotBeNull();
        }

        /// <summary>
        /// Get by id first item should be first item.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetByIdFirstShouldBeFirstTest()
        {
            // Arrange
            var handler = new GetArtByIdHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetArtByIdQuery(1), CancellationToken.None);

            // Assert
            result.Value.Description.Should().Be("First description");
        }

        /// <summary>
        /// Get by id second item description should not be fourth item description test.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetByIdSecondShouldNotBeFourthTest()
        {
            // Arrange
            var handler = new GetArtByIdHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetArtByIdQuery(2), CancellationToken.None);

            // Assert
            result.Value.Description.Should().NotBe("Fourth description");
        }
    }
}
