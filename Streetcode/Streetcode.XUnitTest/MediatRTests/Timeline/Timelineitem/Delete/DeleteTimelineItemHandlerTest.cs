namespace Streetcode.XUnitTest.MediatRTests.Timeline.Timelineitem.Delete
{
    using System.Threading.Tasks;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Interfaces.BlobStorage;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Timeline;
    using Streetcode.BLL.MediatR.Timeline.TimelineItem.Delete;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    /// <summary>
    /// Tested successfully.
    /// </summary>
    public class DeleteTimelineItemHandlerTest
    {
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<IBlobService> mockBlob;
        private readonly Mock<ILoggerService> mockLogger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteTimelineItemHandlerTest"/> class.
        /// </summary>
        public DeleteTimelineItemHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetTimelineRepositoryMock();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<TimelineItemProfile>();
            });

            this.mockBlob = new Mock<IBlobService>();

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
            var handler = new DeleteTimelineItemHandler(this.mockRepository.Object, this.mockBlob.Object, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new DeleteTimelineItemCommand(1), CancellationToken.None);

            // Assert
            result.Value.Should().NotBeNull();
        }
    }
}
