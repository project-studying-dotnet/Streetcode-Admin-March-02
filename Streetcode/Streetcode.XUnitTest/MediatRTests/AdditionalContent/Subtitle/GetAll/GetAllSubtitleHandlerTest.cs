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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Streetcode.XUnitTest.MediatRTests.AdditionalContent.Subtitle.GetAll
{
    public class GetAllSubtitleHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IRepositoryWrapper> _mockRepository;
        private readonly Mock<ILoggerService> _mockLogger;

        public GetAllSubtitleHandlerTest()
        {
            _mockRepository = RepositoryMocker.GetSubtitleRepositoryMock();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<SubtitleProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _mockLogger = new Mock<ILoggerService>();
        }

        [Fact]
        public async Task Handler_GetAll_ResultShouldNotBeNullOrEmpty()
        {
            // Arrange
            var handler = new GetAllSubtitlesHandler(_mockRepository.Object, _mapper, _mockLogger.Object);
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
            var handler = new GetAllSubtitlesHandler(_mockRepository.Object, _mapper, _mockLogger.Object);
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
            var handler = new GetAllSubtitlesHandler(_mockRepository.Object, _mapper, _mockLogger.Object);
            var request = new GetAllSubtitlesQuery();

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Value.Count().Should().Be(3);
        }
    }
}
