namespace Streetcode.XUnitTest.MediatRTests.News.Delete
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Newss;
    using Streetcode.BLL.MediatR.AdditionalContent.Coordinate.Delete;
    using Streetcode.BLL.MediatR.Newss.Delete;
    using Streetcode.DAL.Entities.News;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    public class DeleteNewsHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        public DeleteNewsHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetNewsRepositoryMock();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<NewsProfile>();
            });

            this.mapper = mapperConfig.CreateMapper();

            this.mockLogger = new Mock<ILoggerService>();
        }

        [Fact]
        public async Task Handler_WrongId_IsFailedShouldBeTrue()
        {
            // Arrange
            var handler = new DeleteNewsHandler(this.mockRepository.Object, this.mockLogger.Object);

            int wrongId = 10;
            var request = new DeleteNewsCommand(wrongId);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
        }

        [Fact]
        public async Task Handler_CorrectId_DeleteShouldBeCalled()
        {
            // Arrange
            var handler = new DeleteNewsHandler(this.mockRepository.Object, this.mockLogger.Object);

            int correctId = 1;
            var request = new DeleteNewsCommand(correctId);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            this.mockRepository.Verify(x => x.NewsRepository.Delete(It.IsAny<News>()), Times.Once);
        }
    }
}
