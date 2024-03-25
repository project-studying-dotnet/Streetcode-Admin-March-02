namespace Streetcode.XUnitTest.MediatRTests.Timeline.Timelineitem.Create
{
    using System.Threading.Tasks;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Timeline;
    using Streetcode.BLL.MediatR.Timeline.TimelineItem.Create;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    /// <summary>
    /// Can not test.
    /// </summary>
    public class CreateTimelineItemHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTimelineItemHandlerTest"/> class.
        /// </summary>
        public CreateTimelineItemHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetTimelineRepositoryMock();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<TimelineItemProfile>();
            });

            this.mapper = mapperConfig.CreateMapper();

            this.mockLogger = new Mock<ILoggerService>();
        }

        /// <summary>
        /// Created result should not be null.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task CreatedTimelineItemShouldNotBeNull()
        {
            // Arrange
            var handler = new CreateTimelineItemHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new CreateTimelineItemCommand(new BLL.Dto.Timeline.TimelineItemDto() { Title = "TEST" }), CancellationToken.None);

            // Assert
            result.Value.Should().NotBeNull();
        }

        /// <summary>
        /// Created result title should be "TEST".
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task CreatedTimelineItemTitleShouldBeTest()
        {
            // Arrange
            var handler = new CreateTimelineItemHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new CreateTimelineItemCommand(new BLL.Dto.Timeline.TimelineItemDto() { Title = "TEST" }), CancellationToken.None);

            // Assert
            result.Value.Title.Should().Equals("TEST");
        }
    }
}
