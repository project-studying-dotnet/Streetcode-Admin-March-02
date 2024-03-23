// <copyright file="CreateLocationHandlerTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Streetcode.XUnitTest.MediatRTests.Locations.Create
{
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Locations;
    using Streetcode.BLL.MediatR.Locations.Create;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    /// <summary>
    ///  Can not test.
    /// </summary>
    public class CreateLocationHandlerTest
    {
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly IMapper mapper;
        private readonly Mock<ILoggerService> mockLogger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateLocationHandlerTest"/> class.
        /// </summary>
        public CreateLocationHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetLocationsRepositoryMock();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<LocationProfile>();
            });

            this.mapper = mapperConfig.CreateMapper();

            this.mockLogger = new Mock<ILoggerService>();
        }

        /// <summary>
        /// Create not null and should be created test.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task CreateNotNullLocationMustBeCreated()
        {
            // Arrange
            var handler = new CreateLocationHandler(this.mapper, this.mockRepository.Object, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(
                new CreateLocationCommand(new BLL.Dto.Locations.LocationDto()
                {
                    Id = 1,
                    Streetname = "Created StreetName",
                    TableNumber = 1,
                }), CancellationToken.None);

            // Assert
            result.Value.Should().NotBeNull();
        }
    }
}
