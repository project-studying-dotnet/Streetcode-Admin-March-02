// <copyright file="CreateHistoricalContextHandlerTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Streetcode.XUnitTest.MediatRTests.Timeline.HistoricalContext.Create
{
    using System.Threading.Tasks;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Timeline;
    using Streetcode.BLL.MediatR.Timeline.HistoricalContext.Create;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    /// <summary>
    /// Can not test.
    /// </summary>
    public class CreateHistoricalContextHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateHistoricalContextHandlerTest"/> class.
        /// </summary>
        public CreateHistoricalContextHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetHistoricalContextRepositoryMock();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<HistoricalContextProfile>();
            });

            this.mapper = mapperConfig.CreateMapper();

            this.mockLogger = new Mock<ILoggerService>();
        }

        /// <summary>
        /// Created result should not be null.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task CreatedHistoricalContextShouldNotBeNull()
        {
            // Arrange

            var handler = new CreateHistoricalContextHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new CreateHistoricalContextCommand(new BLL.Dto.Timeline.HistoricalContextDto() { Title = "TEST" }), CancellationToken.None);

            // Assert
            result.Value.Should().NotBeNull();
        }

        /// <summary>
        /// Created result title should be "TEST".
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task CreatedHistoricalContextTitleShouldBeTest()
        {
            // Arrange

            var handler = new CreateHistoricalContextHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new CreateHistoricalContextCommand(new BLL.Dto.Timeline.HistoricalContextDto() { Title = "TEST" }), CancellationToken.None);

            // Assert
            result.Value.Title.Should().Equals("TEST");
        }
    }
}
