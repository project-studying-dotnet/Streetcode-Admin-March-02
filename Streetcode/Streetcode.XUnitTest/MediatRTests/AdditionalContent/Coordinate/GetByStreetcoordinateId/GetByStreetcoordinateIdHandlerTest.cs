namespace Streetcode.XUnitTest.MediatRTests.AdditionalContent.Coordinate.GetByStreetcoordinateId
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
    using Streetcode.BLL.DTO.AdditionalContent.Coordinates.Types;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.AdditionalContent.Coordinates;
    using Streetcode.BLL.MediatR.AdditionalContent.Coordinate.GetByStreetcodeId;
    using Streetcode.DAL.Entities.AdditionalContent.Coordinates;
    using Streetcode.DAL.Entities.AdditionalContent.Coordinates.Types;
    using Streetcode.DAL.Entities.Streetcode;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    public class GetByStreetcoordinateIdHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        private readonly List<StreetcodeCoordinate> _coordinates = new List<StreetcodeCoordinate>
        {
            new StreetcodeCoordinate
            {
                Id = 1,
                StreetcodeId = 1,
            },
            new StreetcodeCoordinate
            {
                Id = 2,
                StreetcodeId = 1,
            },
        };

        public GetByStreetcoordinateIdHandlerTest()
        {
            this.mockRepository = new Mock<IRepositoryWrapper>();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<StreetcodeCoordinateProfile>();
            });

            this.mapper = mapperConfig.CreateMapper();

            this.mockLogger = new Mock<ILoggerService>();
        }

        [Fact]
        public async Task Handle_ValidData_ValueShouldBeOfTypeListStreetcodeCoordinateDTO()
        {
            // Arrange
            await SetupRepository(_coordinates, new StreetcodeContent());

            var handler = new GetCoordinatesByStreetcodeIdHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);
            int streetCodeid = 1;
            var getCoordinatesByStreetcodeIdQuery = new GetCoordinatesByStreetcodeIdQuery(streetCodeid);

            // Act
            var result = await handler.Handle(getCoordinatesByStreetcodeIdQuery, CancellationToken.None);

            // Assert
            result.Value.Should().BeOfType<List<StreetcodeCoordinateDTO>>();
        }

        [Fact]
        public async Task Handle_StreetccodeCoordinatesIsEmpty_ResultShouldBeEmpty()
        {
            // Arrange
            await SetupRepository(new List<StreetcodeCoordinate>(), new StreetcodeContent());

            var handler = new GetCoordinatesByStreetcodeIdHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);
            int streetCodeid = 1;
            var getCoordinatesByStreetcodeIdQuery = new GetCoordinatesByStreetcodeIdQuery(streetCodeid);

            // Act
            var result = await handler.Handle(getCoordinatesByStreetcodeIdQuery, CancellationToken.None);

            // Assert
            result.Value.Should().BeEmpty();
        }

        private async Task SetupRepository(List<StreetcodeCoordinate> coordinates, StreetcodeContent streetcode)
        {
            this.mockRepository.Setup(x => x.StreetcodeCoordinateRepository.GetAllAsync(
                It.IsAny<Expression<Func<StreetcodeCoordinate, bool>>>(),
                It.IsAny<Func<IQueryable<StreetcodeCoordinate>,
                IIncludableQueryable<StreetcodeCoordinate, object>>>())).ReturnsAsync(coordinates);

            this.mockRepository.Setup(x => x.StreetcodeRepository
                .GetFirstOrDefaultAsync(
                   It.IsAny<Expression<Func<StreetcodeContent, bool>>>(),
                   It.IsAny<Func<IQueryable<StreetcodeContent>,
                    IIncludableQueryable<StreetcodeContent, object>>>()))
                .ReturnsAsync(streetcode);
        }
    }
}
