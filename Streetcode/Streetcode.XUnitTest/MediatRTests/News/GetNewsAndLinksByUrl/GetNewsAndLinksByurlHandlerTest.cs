using AutoMapper;
using FluentAssertions;
using Moq;
using Streetcode.BLL.Dto.News;
using Streetcode.BLL.Interfaces.BlobStorage;
using Streetcode.BLL.Interfaces.Logging;
using Streetcode.BLL.Mapping.Newss;
using Streetcode.BLL.MediatR.Newss.GetByUrl;
using Streetcode.BLL.MediatR.Newss.GetNewsAndLinksByUrl;
using Streetcode.DAL.Repositories.Interfaces.Base;
using Streetcode.XUnitTest.MediatRTests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Streetcode.XUnitTest.MediatRTests.News.GetNewsAndLinksByUrl
{
    public class GetNewsAndLinksByurlHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;
        private readonly Mock<IBlobService> blobService;

        public GetNewsAndLinksByurlHandlerTest()
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
        public async Task Handler_GetNewsAndLinksByInvalidUrl_IsFailedShouldBeTrue()
        {
            // Arrange
            var handler = new GetNewsAndLinksByUrlHandler(this.mapper, this.mockRepository.Object, this.blobService.Object, this.mockLogger.Object);
            string invalidUrl = string.Empty;
            var request = new GetNewsAndLinksByUrlQuery(invalidUrl);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
        }

        [Fact]
        public async Task Handler_GetNewsAndLinksByValidUrl_PreviousNewsLinkShouldBeAsExpected()
        {
            // Arrange
            var handler = new GetNewsAndLinksByUrlHandler(this.mapper, this.mockRepository.Object, this.blobService.Object, this.mockLogger.Object);
            string validUrl = "example2.com";
            string expectedPreviousNewsUrl = "example1.com";
            var request = new GetNewsAndLinksByUrlQuery(validUrl);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Value.PrevNewsUrl.Should().Be(expectedPreviousNewsUrl);
        }

        [Fact]
        public async Task Handler_GetNewsAndLinksByValidUrl_NextNewsLinkShouldBeAsExpected()
        {
            // Arrange
            var handler = new GetNewsAndLinksByUrlHandler(this.mapper, this.mockRepository.Object, this.blobService.Object, this.mockLogger.Object);
            string validUrl = "example2.com";
            string expectedNextNewsUrl = "example3.com";
            var request = new GetNewsAndLinksByUrlQuery(validUrl);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Value.NextNewsUrl.Should().Be(expectedNextNewsUrl);
        }

        [Fact]
        public async Task Handler_GetNewsAndLinksByValidUrl_PreviousNewsLinkShouldBeNull()
        {
            // Arrange
            var handler = new GetNewsAndLinksByUrlHandler(this.mapper, this.mockRepository.Object, this.blobService.Object, this.mockLogger.Object);
            string validUrl = "example1.com";
            var request = new GetNewsAndLinksByUrlQuery(validUrl);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Value.PrevNewsUrl.Should().BeNull();
        }

        [Fact]
        public async Task Handler_GetNewsAndLinksByValidUrl_NextNewsLinkShouldBeNull()
        {
            // Arrange
            var handler = new GetNewsAndLinksByUrlHandler(this.mapper, this.mockRepository.Object, this.blobService.Object, this.mockLogger.Object);
            string validUrl = "example3.com";
            var request = new GetNewsAndLinksByUrlQuery(validUrl);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Value.NextNewsUrl.Should().BeNull();
        }

        [Fact]
        public async Task Handler_GetNewsAndLinksByValidUrl_ResultShouldBeOfTypeNewsDtoWithURLs()
        {
            // Arrange
            var handler = new GetNewsAndLinksByUrlHandler(this.mapper, this.mockRepository.Object, this.blobService.Object, this.mockLogger.Object);
            string validUrl = "example2.com";
            var request = new GetNewsAndLinksByUrlQuery(validUrl);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Value.Should().BeOfType<NewsDtoWithURLs>();
        }

        [Fact]
        public async Task Handler_GetNewsAndLinksByValidUrl_RandomNewsUrlShouldBeAsValidUrl()
        {
            // Arrange
            var handler = new GetNewsAndLinksByUrlHandler(this.mapper, this.mockRepository.Object, this.blobService.Object, this.mockLogger.Object);
            string validUrl = "example2.com";
            var request = new GetNewsAndLinksByUrlQuery(validUrl);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Value.RandomNews?.RandomNewsUrl.Should().Be(validUrl);
        }
    }
}
