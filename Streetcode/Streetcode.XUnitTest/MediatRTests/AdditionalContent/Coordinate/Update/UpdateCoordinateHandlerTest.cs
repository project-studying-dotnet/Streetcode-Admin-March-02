namespace Streetcode.XUnitTest.MediatRTests.AdditionalContent.Coordinate.Update
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.DTO.AdditionalContent.Coordinates.Types;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.AdditionalContent.Coordinates;
    using Streetcode.BLL.MediatR.AdditionalContent.Coordinate.Create;
    using Streetcode.BLL.MediatR.AdditionalContent.Coordinate.Update;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    public class UpdateCoordinateHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        public UpdateCoordinateHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetCoordinateRepositoryMock();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<StreetcodeCoordinateProfile>();
            });

            this.mapper = mapperConfig.CreateMapper();

            this.mockLogger = new Mock<ILoggerService>();
        }

        [Fact]
        public async Task Handler_CoordinateDTOIsNull_IsFaildeShouldBeTrue()
        {
            // Arrange
            var handler = new UpdateCoordinateHandler(this.mockRepository.Object, this.mapper);
            StreetcodeCoordinateDTO? streetcodeCoordinateDTO = null;
            var streetcodeCoordinate = new UpdateCoordinateCommand(streetcodeCoordinateDTO);

            // Act
            var result = await handler.Handle(streetcodeCoordinate, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
        }

        [Fact]
        public async Task Handler_ValidData_IsSucessShouldBeTrue()
        {
            // Arrange
            var handler = new UpdateCoordinateHandler(this.mockRepository.Object, this.mapper);
            var streetcodeCoordinateDTO = new StreetcodeCoordinateDTO()
            {
                StreetcodeId = 1,
                Id = 1,
                Latitude = 1,
                Longtitude = 1,
            };
            var streetcodeCoordinate = new UpdateCoordinateCommand(streetcodeCoordinateDTO);

            // Act
            var result = await handler.Handle(streetcodeCoordinate, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
        }
    }
}
