// <copyright file="GetPartnerByStreetcodeId.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Streetcode.XUnitTest.MediatRTests.Partners.GetByStreetcodeId
{
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Partners;
    using Streetcode.BLL.MediatR.Partners.GetByStreetcodeId;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    /// <summary>
    /// Can not test.
    /// </summary>
    public class GetPartnerByStreetcodeIdHandlerTest
    {
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly IMapper mapper;
        private readonly Mock<ILoggerService> mockLogger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetPartnerByStreetcodeIdHandlerTest"/> class.
        /// </summary>
        public GetPartnerByStreetcodeIdHandlerTest()
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
        /// Get by id not null test.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetByIdNotNullTest()
        {
            // Arrange
            var handler = new GetPartnersByStreetcodeIdHandler(this.mapper, this.mockRepository.Object, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetPartnersByStreetcodeIdQuery(1), CancellationToken.None);

            // Assert
            result.Value.Should().NotBeNull();
        }

        /// <summary>
        /// Get by id second item Title should be second Title.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetByIdSecondTitleShouldBeSecond()
        {
            // Arrange
            var handler = new GetPartnersByStreetcodeIdHandler(this.mapper, this.mockRepository.Object, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetPartnersByStreetcodeIdQuery(1), CancellationToken.None);

            // Assert
            result.Value.ElementAt(1).Title.Should().Be("Second Title");
        }
    }
}
