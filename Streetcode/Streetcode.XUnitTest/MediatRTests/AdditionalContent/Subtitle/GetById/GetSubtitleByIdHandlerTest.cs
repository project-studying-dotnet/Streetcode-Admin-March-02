namespace Streetcode.XUnitTest.MediatRTests.AdditionalContent.Subtitle.GetById
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
    using Streetcode.BLL.MediatR.AdditionalContent.GetById;
    using Streetcode.BLL.MediatR.AdditionalContent.Subtitle.GetById;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    public class GetSubtitleByIdHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        public GetSubtitleByIdHandlerTest()
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
        public async Task Handler_GetSubtitleByValidId_GetByIdResultShouldBeNotNull()
        {
            // Arrange
            var handler = new GetSubtitleByIdHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);
            int validId = 1;
            var request = new GetSubtitleByIdQuery(validId);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task Handler_GetSubtitleByInvalidId_IsFailedShouldBeTrue()
        {
            // Arrange
            var handler = new GetSubtitleByIdHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);
            int invalidId = 10;
            var request = new GetSubtitleByIdQuery(invalidId);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
        }
    }
}
