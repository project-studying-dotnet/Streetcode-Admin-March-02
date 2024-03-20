// <copyright file="GetAllToponymsHandlerTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Streetcode.XUnitTest.MediatRTests.Toponyms.GetAll
{
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.DTO.Media.Art;
    using Streetcode.BLL.DTO.Toponyms;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Toponyms;
    using Streetcode.BLL.MediatR.Media.Art.GetAll;
    using Streetcode.BLL.MediatR.Toponyms.GetAll;
    using Streetcode.DAL.Entities.Toponyms;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    /// <summary>
    /// Tested successfully.
    /// </summary>
    public class GetAllToponymsHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;


        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllToponymsHandlerTest"/> class.
        /// </summary>
        public GetAllToponymsHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetToponymsRepositoryMock();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<ToponymProfile>();
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
            var handler = new GetAllToponymsHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);
           
            // Act
            var result = await handler.Handle(new GetAllToponymsQuery(new GetAllToponymsRequestDTO() { Title = "First streetname" }), CancellationToken.None);

            // Assert
            result.Value.Should().NotBeNull();
        }


        /// <summary>
        /// Get all list should be type ArtDTO.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetAllShouldBeTypeListToponymDTO()
        {
            // Arrange
            var handler = new GetAllToponymsHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetAllToponymsQuery(new GetAllToponymsRequestDTO() { Title = "First streetname" }), CancellationToken.None);

            // Assert
            result.Value.Toponyms.Should().BeOfType<List<ToponymDTO>>();
        }
    }
}
