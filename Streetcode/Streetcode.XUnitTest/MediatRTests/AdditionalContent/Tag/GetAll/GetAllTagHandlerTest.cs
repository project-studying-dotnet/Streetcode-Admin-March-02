namespace Streetcode.XUnitTest.MediatRTests.AdditionalContent.Tag.GetAll
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore.Query;
    using Moq;
    using Streetcode.BLL.DTO.AdditionalContent;
    using Streetcode.BLL.DTO.AdditionalContent.Subtitles;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.AdditionalContent;
    using Streetcode.BLL.MediatR.AdditionalContent.Subtitle.GetAll;
    using Streetcode.BLL.MediatR.AdditionalContent.Tag.GetAll;
    using Streetcode.DAL.Entities.AdditionalContent;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    public class GetAllTagHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        public GetAllTagHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetTagRepositoryMock();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<TagProfile>();
            });

            this.mapper = mapperConfig.CreateMapper();

            this.mockLogger = new Mock<ILoggerService>();
        }

        [Fact]
        public async Task Handler_GetAll_ResultShouldNotBeNullOrEmpty()
        {
            // Arrange
            var handler = new GetAllTagsHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);
            var request = new GetAllTagsQuery();

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Value.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task Handler_GetAll_ResultShouldBeOfTypeSubtitleDTO()
        {
            // Arrange
            var handler = new GetAllTagsHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);
            var request = new GetAllTagsQuery();

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Value.Should().BeOfType<List<TagDTO>>();
        }

        [Fact]
        public async Task Handler_GetAll_CountShouldBeTwo()
        {
            // Arrange
            var handler = new GetAllTagsHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);
            var request = new GetAllTagsQuery();
            int expectedCount = 2;

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Value.Count().Should().Be(expectedCount);
        }

        [Fact]
        public async Task Handler_TagRepositoryIsEmpty_IsFailedShouldBeTrue()
        {
            // Arrange
            this.mockRepository.Setup(x => x.TagRepository.GetAllAsync(
                It.IsAny<Expression<Func<Tag, bool>>>(),
                It.IsAny<Func<IQueryable<Tag>,
                IIncludableQueryable<Tag, object>>>()))
                .Returns(Task.FromResult<IEnumerable<Tag>>(null));

            var handler = new GetAllTagsHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);
            var request = new GetAllTagsQuery();

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
        }
    }
}
