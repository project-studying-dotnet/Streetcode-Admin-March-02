namespace Streetcode.XUnitTest.MediatRTests.Timeline.Timelineitem.Update
{
    using System.Threading.Tasks;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Dto.Timeline;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Timeline;
    using Streetcode.BLL.MediatR.Timeline.TimelineItem.Update;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    /// <summary>
    /// Can not test.
    /// </summary>
    public class UpdateTimelineItemHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateTimelineItemHandlerTest"/> class.
        /// </summary>
        public UpdateTimelineItemHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetCoordinateRepositoryMock();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<TimelineItemProfile>();
            });

            this.mapper = mapperConfig.CreateMapper();

            this.mockLogger = new Mock<ILoggerService>();
        }

        [Fact]
        public async Task Handler_CoordinateDTOIsNull_IsFaildeShouldBeTrue()
        {
            // Arrange
            var handler = new UpdateTimelineItemHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);
            TimelineItemDto? timeline = null;
            var streetcodeCoordinate = new UpdateTimelineItemCommand(timeline);

            // Act
            var result = await handler.Handle(streetcodeCoordinate, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
        }

        [Fact]
        public async Task Handler_ValidData_IsSucessShouldBeTrue()
        {
            // Arrange
            var handler = new UpdateTimelineItemHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);
            var timeline = new TimelineItemDto()
            {
               Id=1,
               Title="BEBEBBEBE"
            };
            var updatedTimeline = new UpdateTimelineItemCommand(timeline);

            // Act
            var result = await handler.Handle(updatedTimeline, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
        }
    }
}
