namespace Streetcode.XUnitTest.MediatRTests.AdditionalContent.Tag.GetById
{
    using System.Threading.Tasks;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.AdditionalContent;
    using Streetcode.BLL.MediatR.AdditionalContent.Tag.GetById;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    public class GetTagByIdHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        public GetTagByIdHandlerTest()
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
        public async Task Handler_GetTagByValidId_GetByIdResultShouldBeNotNull()
        {
            // Arrange
            var handler = new GetTagByIdHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);
            int validId = 1;
            var request = new GetTagByIdQuery(validId);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task Handler_GetTagByInvalidId_IsFailedShouldBeTrue()
        {
            // Arrange
            var handler = new GetTagByIdHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);
            int invalidId = 10;
            var request = new GetTagByIdQuery(invalidId);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
        }
    }
}
