namespace Streetcode.XUnitTest.MediatRTests.AdditionalContent.Tag.GetTagByTitle
{
    using System.Threading.Tasks;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.AdditionalContent;
    using Streetcode.BLL.MediatR.AdditionalContent.Tag.GetByStreetcodeId;
    using Streetcode.BLL.MediatR.AdditionalContent.Tag.GetTagByTitle;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    public class GetTagByTitleHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        public GetTagByTitleHandlerTest()
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
        public async Task Handler_GetTagByValidTitle_GetByIdResultShouldBeNotNull()
        {
            // Arrange
            var handler = new GetTagByTitleHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);
            string validTitle = "Test";
            var request = new GetTagByTitleQuery(validTitle);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task Handler_GetTagByInvalidTitle_IsFailedShouldBeTrue()
        {
            // Arrange
            var handler = new GetTagByTitleHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);
            string invalidTitle = "Title doesn't exist";
            var request = new GetTagByTitleQuery(invalidTitle);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
        }
    }
}
