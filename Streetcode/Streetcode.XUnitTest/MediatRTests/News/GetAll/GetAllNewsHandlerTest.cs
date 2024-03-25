namespace Streetcode.XUnitTest.MediatRTests.News.GetAll
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Dto.AdditionalContent.Subtitles;
    using Streetcode.BLL.Dto.News;
    using Streetcode.BLL.Interfaces.BlobStorage;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Newss;
    using Streetcode.BLL.MediatR.AdditionalContent.Subtitle.GetAll;
    using Streetcode.BLL.MediatR.Newss.GetAll;
    using Streetcode.BLL.Services.BlobStorageService;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    public class GetAllNewsHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;
        private readonly Mock<IBlobService> blobService;

        public GetAllNewsHandlerTest()
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
        public async Task Handler_GetAll_ResultShouldNotBeNullOrEmpty()
        {
            // Arrange
            var handler = new GetAllNewsHandler(this.mockRepository.Object, this.mapper, this.blobService.Object, this.mockLogger.Object);
            var request = new GetAllNewsQuery();

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Value.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task Handler_GetAll_ResultShouldBeOfTypeSubtitleDTO()
        {
            // Arrange
            var handler = new GetAllNewsHandler(this.mockRepository.Object, this.mapper, this.blobService.Object, this.mockLogger.Object);
            var request = new GetAllNewsQuery();

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Value.Should().BeOfType<List<NewsDto>>();
        }

        [Fact]
        public async Task Handler_GetAll_CountShouldBeThree()
        {
            // Arrange
            var handler = new GetAllNewsHandler(this.mockRepository.Object, this.mapper, this.blobService.Object, this.mockLogger.Object);
            var request = new GetAllNewsQuery();

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Value.Count().Should().Be(3);
        }
    }
}
