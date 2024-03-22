namespace Streetcode.XUnitTest.MediatRTests.AdditionalContent.Subtitle.GetByStreetcodeId
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
    using Streetcode.BLL.Mapping.AdditionalContent;
    using Streetcode.BLL.MediatR.AdditionalContent.Subtitle.GetByStreetcodeId;
    using Streetcode.BLL.MediatR.Media.Audio.GetByStreetcodeId;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    public class GetSubtitleByStreetcodeIdHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        public GetSubtitleByStreetcodeIdHandlerTest()
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
        public async Task Handler_GetByStreetcodeValidId_ResultShouldNotBeNull()
        {
            // Arrange
            var handler = new GetSubtitlesByStreetcodeIdHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);
            int validId = 1;
            var request = new GetSubtitlesByStreetcodeIdQuery(validId);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task Handler_GetByStreetcodeInvalidId_ResultShouldBeNull()
        {
            // Arrange
            var handler = new GetSubtitlesByStreetcodeIdHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);
            int invalidId = 10;
            var request = new GetSubtitlesByStreetcodeIdQuery(invalidId);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Value.Should().BeNull();
        }
    }
}
