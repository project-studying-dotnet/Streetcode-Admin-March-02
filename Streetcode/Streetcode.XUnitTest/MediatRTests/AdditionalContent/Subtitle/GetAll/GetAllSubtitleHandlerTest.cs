namespace Streetcode.XUnitTest.MediatRTests.AdditionalContent.Subtitle.GetAll
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.DTO.AdditionalContent.Subtitles;
    using Streetcode.BLL.DTO.Media.Art;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.AdditionalContent;
    using Streetcode.BLL.Mapping.Media.Images;
    using Streetcode.BLL.MediatR.AdditionalContent.Subtitle.GetAll;
    using Streetcode.BLL.MediatR.Media.Art.GetAll;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    public class GetAllSubtitleHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        public GetAllSubtitleHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetSubtitleRepositoryMock();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<SubtitleProfile>();
            });

            this.mapper = mapperConfig.CreateMapper();

            this.mockLogger = new Mock<ILoggerService>();
        }

        [Fact]
        public async Task Handler_GetAll_ResultShouldNotBeNullOrEmpty()
        {
            // Arrange
            var handler = new GetAllSubtitlesHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);
            var request = new GetAllSubtitlesQuery();

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Value.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task Handler_GetAll_ResultShouldBeOfTypeSubtitleDTO()
        {
            // Arrange
            var handler = new GetAllSubtitlesHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);
            var request = new GetAllSubtitlesQuery();

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Value.Should().BeOfType<List<SubtitleDTO>>();
        }

        [Fact]
        public async Task Handler_GetAll_CountShouldBeThree()
        {
            // Arrange
            var handler = new GetAllSubtitlesHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);
            var request = new GetAllSubtitlesQuery();

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Value.Count().Should().Be(3);
        }
    }
}
