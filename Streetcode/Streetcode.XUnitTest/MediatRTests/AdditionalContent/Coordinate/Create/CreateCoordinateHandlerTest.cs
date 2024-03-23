namespace Streetcode.XUnitTest.MediatRTests.AdditionalContent.Coordinate.Create
{
    using System.Threading.Tasks;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Dto.AdditionalContent.Coordinates.Types;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.MediatR.AdditionalContent.Coordinate.Create;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    public class CreateCoordinateHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        public CreateCoordinateHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetCoordinateRepositoryMock();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<BLL.Mapping.AdditionalContent.Coordinates.StreetcodeCoordinateProfile>();
            });

            this.mapper = mapperConfig.CreateMapper();

            this.mockLogger = new Mock<ILoggerService>();
        }

        [Fact]
        public async Task CreateCoordinate_CoordinateDTOIsNull_IsFailedShouldBeTrue()
        {
            // Arrange
            var handler = new CreateCoordinateHandler(this.mockRepository.Object, this.mapper);
            PaymentResponseDTO? streetcodeCoordinateDTO = null;
            var streetcodeCoordinate = new CreateCoordinateCommand(streetcodeCoordinateDTO);

            // Act
            var result = await handler.Handle(streetcodeCoordinate, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
        }

        [Fact]
        public async Task CreateCoordinate_ValidData_IsSuccessShouldBeTrue()
        {
            // Arrange
            var handler = new CreateCoordinateHandler(this.mockRepository.Object, this.mapper);
            var streetcodeCoordinateDTO = new PaymentResponseDTO()
            {
                StreetcodeId = 1,
                Id = 1,
                Latitude = 1,
                Longtitude = 1,
            };

            var streetcodeCoordinate = new CreateCoordinateCommand(streetcodeCoordinateDTO);

            // Act
            var result = await handler.Handle(streetcodeCoordinate, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
        }
    }
}
