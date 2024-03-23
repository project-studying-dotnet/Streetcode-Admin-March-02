namespace Streetcode.XUnitTest.MediatRTests.AdditionalContent.Tag.Create
{
    using System.Threading.Tasks;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Dto.AdditionalContent;
    using Streetcode.BLL.Dto.AdditionalContent.Tag;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.AdditionalContent;
    using Streetcode.BLL.MediatR.AdditionalContent.Tag.Create;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    public class CreateTagHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        public CreateTagHandlerTest()
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
        public async Task Handler_ValidData_IsSuccessShouldBeTrue()
        {
            // Arrange
            var handler = new CreateTagHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);
            var tagDTO = new CreateTagDto() { Title = "Test" };
            var request = new CreateTagQuery(tagDTO);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Handler_ValidData_ResultShouldBeOfTypeTagDTO()
        {
            // Arrange
            var handler = new CreateTagHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);
            var tagDTO = new CreateTagDto() { Title = "Test" };
            var request = new CreateTagQuery(tagDTO);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Value.Should().BeOfType<TagDto>();
        }

        [Fact]
        public async Task Handler_CreateTag_IsFailedShouldBeTrue()
        {
            // Arrange
            var handler = new CreateTagHandler(RepositoryMocker.GetTagRepositoryMockWithSettingException().Object, this.mapper, this.mockLogger.Object);
            var tagDTO = new CreateTagDto();
            var request = new CreateTagQuery(tagDTO);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
        }
    }
}
