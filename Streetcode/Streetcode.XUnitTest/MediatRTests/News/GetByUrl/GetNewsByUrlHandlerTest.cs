namespace Streetcode.XUnitTest.MediatRTests.News.GetByUrl
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
    using Streetcode.BLL.MediatR.Newss.GetById;
    using Streetcode.BLL.MediatR.Newss.GetByUrl;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    public class GetNewsByUrlHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;
        private readonly Mock<IBlobService> blobService;

        public GetNewsByUrlHandlerTest()
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
        public async Task Handler_GetNewsByValidUrl_ResultShouldBeNotNull()
        {
            // Arrange
            var handler = new GetNewsByUrlHandler(this.mapper, this.mockRepository.Object, this.blobService.Object, this.mockLogger.Object);
            string validUrl = "example.com";
            var request = new GetNewsByUrlQuery(validUrl);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task Handler_GetNewsByInvalidUrl_IsFailedShouldBeTrue()
        {
            // Arrange
            var handler = new GetNewsByUrlHandler(this.mapper, this.mockRepository.Object, this.blobService.Object, this.mockLogger.Object);
            string invalidUrl = string.Empty;
            var request = new GetNewsByUrlQuery(invalidUrl);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
        }

        [Fact]
        public async Task Handler_GetNewsByValidUrl_ResultShouldBeTypeOfNewsDto()
        {
            // Arrange
            var handler = new GetNewsByUrlHandler(this.mapper, this.mockRepository.Object, this.blobService.Object, this.mockLogger.Object);
            string validUrl = "example.com";
            var request = new GetNewsByUrlQuery(validUrl);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Value.Should().BeOfType<NewsDto>();
        }
    }
}
