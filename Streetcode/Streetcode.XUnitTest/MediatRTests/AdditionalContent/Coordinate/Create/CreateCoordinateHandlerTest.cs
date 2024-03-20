namespace Streetcode.XUnitTest.MediatRTests.AdditionalContent.Coordinate.Create
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using FluentAssertions;
    using MediatR;
    using Moq;
    using Streetcode.BLL.DTO.AdditionalContent.Coordinates.Types;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.AdditionalContent.Coordinates;
    using Streetcode.BLL.Mapping.Media.Images;
    using Streetcode.BLL.MediatR.AdditionalContent.Coordinate.Create;
    using Streetcode.BLL.MediatR.Media.Art.GetAll;
    using Streetcode.DAL.Entities.AdditionalContent.Coordinates;
    using Streetcode.DAL.Entities.AdditionalContent.Coordinates.Types;
    using Streetcode.DAL.Entities.Streetcode;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    public class CreateCoordinateHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IRepositoryWrapper> _mockRepository;
        private readonly Mock<ILoggerService> _mockLogger;

        public CreateCoordinateHandlerTest()
        {
            _mockRepository = RepositoryMocker.GetCoordinateRepositoryMock();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<BLL.Mapping.AdditionalContent.Coordinates.StreetcodeCoordinateProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _mockLogger = new Mock<ILoggerService>();
        }

        [Fact]
        public async Task CreateCoordinate_CoordinateDTOIsNull_IsFailedShouldBeTrue()
        {
            // Arrange
            var handler = new CreateCoordinateHandler(_mockRepository.Object, _mapper);
            StreetcodeCoordinateDTO? streetcodeCoordinateDTO = null;
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
            var handler = new CreateCoordinateHandler(_mockRepository.Object, _mapper);
            var streetcodeCoordinateDTO = new StreetcodeCoordinateDTO()
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
