// <copyright file="DeletePartnerHandlerTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Streetcode.XUnitTest.MediatRTests.Partners.Delete
{
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Partners;
    using Streetcode.BLL.MediatR.Partners.Delete;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    /// <summary>
    /// Tested successfully.
    /// </summary>
    public class DeletePartnerHandlerTest
    {
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly IMapper mapper;
        private readonly Mock<ILoggerService> mockLogger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeletePartnerHandlerTest"/> class.
        /// </summary>
        public DeletePartnerHandlerTest()
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
        /// Delete item with first id result should not be null test.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteWithFirstIdShouldNotBeNull()
        {
            // Arrange
            var handler = new DeletePartnerHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new DeletePartnerQuery(1), CancellationToken.None);

            // Assert
            result.Value.Should().NotBeNull();
        }
    }
}
