// <copyright file="GetSourceByStreetcodeIdHandlerTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Streetcode.XUnitTest.MediatRTests.Sources.SourceLinkCategory.GetByStreetcodeId
{
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Interfaces.BlobStorage;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Sources;
    using Streetcode.BLL.MediatR.Sources.SourceLink.GetCategoriesByStreetcodeId;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    /// <summary>
    /// Can not test.
    /// </summary>
    public class GetSourceByStreetcodeIdHandlerTest
    {
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly IMapper mapper;
        private readonly Mock<IBlobService> mockBlob;
        private readonly Mock<ILoggerService> mockLogger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSourceByStreetcodeIdHandlerTest"/> class.
        /// </summary>
        public GetSourceByStreetcodeIdHandlerTest()
        {
            mockRepository = RepositoryMocker.GetSourceRepositoryMock();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<SourceLinkCategoryProfile>();
            });

            mapper = mapperConfig.CreateMapper();

            mockLogger = new Mock<ILoggerService>();

            mockBlob = new Mock<IBlobService>();
        }

        /// <summary>
        /// Get by id not null test.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetByIdNotNullTest()
        {
            // Arrange
            var handler = new GetCategoriesByStreetcodeIdHandler(mockRepository.Object, mapper, mockBlob.Object, mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetCategoriesByStreetcodeIdQuery(1), CancellationToken.None);

            // Assert
            result.Value.Should().NotBeNull();
        }

        /// <summary>
        /// Get by id second item title name should be second title name.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetByIdSecondBlobNameShouldBeSecond()
        {
            // Arrange
            var handler = new GetCategoriesByStreetcodeIdHandler(mockRepository.Object, mapper, mockBlob.Object, mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetCategoriesByStreetcodeIdQuery(1), CancellationToken.None);

            // Assert
            result.Value.ElementAt(1).Title.Should().Be("Second title");
        }
    }
}
