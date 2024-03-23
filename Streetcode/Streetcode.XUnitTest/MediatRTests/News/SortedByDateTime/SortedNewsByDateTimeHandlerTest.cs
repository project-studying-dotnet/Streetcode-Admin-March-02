namespace Streetcode.XUnitTest.MediatRTests.News.SortedByDateTime
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Dto.News;
    using Streetcode.BLL.Interfaces.BlobStorage;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Newss;
    using Streetcode.BLL.MediatR.Newss.GetNewsAndLinksByUrl;
    using Streetcode.BLL.MediatR.Newss.SortedByDateTime;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    public class SortedNewsByDateTimeHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;
        private readonly Mock<IBlobService> blobService;

        public SortedNewsByDateTimeHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetNewsRepositoryMock();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<NewsProfile>();
            });

            this.mapper = mapperConfig.CreateMapper();

            this.mockLogger = new Mock<ILoggerService>();

            this.blobService = new Mock<IBlobService>();
        }

        [Fact]
        public async Task Handler_SortedNewsByDateTime_ResultShouldBeOfTypeListNewsDto()
        {
            // Arrange
            var handler = new SortedByDateTimeHandler(this.mockRepository.Object, this.mapper, this.blobService.Object, this.mockLogger.Object);
            var request = new SortedByDateTimeQuery();

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Value.Should().BeOfType<List<NewsDto>>();
        }

        [Fact]
        public async Task Handler_SortedNewsByDateTime_DateTimeOfFirstItemShouldBeAsExpected()
        {
            // Arrange
            var handler = new SortedByDateTimeHandler(this.mockRepository.Object, this.mapper, this.blobService.Object, this.mockLogger.Object);
            var request = new SortedByDateTimeQuery();
            var expectedDate = new DateTime(2024, 3, 23, 0, 0, 0, DateTimeKind.Utc);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Value[0].CreationDate.Should().Be(expectedDate);
        }
    }
}
