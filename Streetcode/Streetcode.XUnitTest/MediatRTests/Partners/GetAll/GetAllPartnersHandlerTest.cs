// <copyright file="GetAllPartnersHandlerTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Streetcode.XUnitTest.MediatRTests.Partners.GetAll
{
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Dto.Partners;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Partners;
    using Streetcode.BLL.MediatR.Partners.GetAll;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    /// <summary>
    /// TESTED SUCCESSFULLY.
    /// </summary>
    public class GetAllPartnersHandlerTest
    {
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly IMapper mapper;
        private readonly Mock<ILoggerService> mockLogger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllPartnersHandlerTest"/> class.
        /// </summary>
        public GetAllPartnersHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetPartnersRepositoryMock();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<PartnerProfile>();
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
            var handler = new GetAllPartnersHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetAllPartnersQuery(), CancellationToken.None);

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
            var handler = new GetAllPartnersHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetAllPartnersQuery(), CancellationToken.None);

            // Assert
            result.Value.Count().Should().Be(4);
        }

        /// <summary>
        /// Get all list should be type PartnerDTO.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetAllShouldBeTypeListPartnerDTO()
        {
            // Arrange
            var handler = new GetAllPartnersHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetAllPartnersQuery(), CancellationToken.None);

            // Assert
            result.Value.Should().BeOfType<List<PartnerDto>>();
        }
    }
}
