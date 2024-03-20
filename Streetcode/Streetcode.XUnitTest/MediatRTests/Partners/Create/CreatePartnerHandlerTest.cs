// <copyright file="CreatePartnerHandlerTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Streetcode.XUnitTest.MediatRTests.Partners.Create
{
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.DTO.Partners;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Partners;
    using Streetcode.BLL.MediatR.Partners.Create;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    /// <summary>
    ///  Can not test.
    /// </summary>
    public class CreatePartnerHandlerTest
    {
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly IMapper mapper;
        private readonly Mock<ILoggerService> mockLogger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreatePartnerHandlerTest"/> class.
        /// </summary>
        public CreatePartnerHandlerTest()
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
        /// Create not null and should be created test.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task CreateNotNullPartnerMustBeCreated()
        {
            // Arrange
            var handler = new CreatePartnerHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(
                new CreatePartnerQuery(new CreatePartnerDTO()
                {
                    Id = 1,
                    IsKeyPartner = true,
                    IsVisibleEverywhere = true,
                    Title = "Created title",
                    Description = "Created description",
                    TargetUrl = "Created target url",
                    LogoId = 1,
                    UrlTitle = "Created url title",
                }), CancellationToken.None);

            // Assert
            result.Value.Should().NotBeNull();
        }
    }
}
