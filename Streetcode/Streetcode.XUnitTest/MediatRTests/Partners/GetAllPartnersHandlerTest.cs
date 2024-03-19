using AutoMapper;
using FluentAssertions;
using Moq;
using Streetcode.BLL.DTO.Partners;
using Streetcode.BLL.Interfaces.Logging;
using Streetcode.BLL.Mapping.Partners;
using Streetcode.BLL.MediatR.Partners.GetAll;
using Streetcode.DAL.Repositories.Interfaces.Base;
using Streetcode.XUnitTest.MediatRTests.Mocks;
using Xunit;

namespace Streetcode.XUnitTest.MediatRTests.Partners
{
    // TESTED SUCCESSFULLY
    // BLL -> MediatR -> Partners -> GetAll
    public class GetAllPartnersHandlerTest
    {
        private readonly Mock<IRepositoryWrapper> _mockRepository;
        private readonly IMapper _mapper;
        private readonly Mock<ILoggerService> _mockLogger;

        public GetAllPartnersHandlerTest()
        {
            _mockRepository = RepositoryMocker.GetPartnersRepositoryMock();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<PartnerProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _mockLogger = new Mock<ILoggerService>();
        }

        [Fact]
        public async Task Get_All_Not_Null_Or_Empty_Test()
        {
            // Arrange
            var handler = new GetAllPartnersHandler(_mockRepository.Object, _mapper, _mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetAllPartnersQuery(), CancellationToken.None);

            // Assert
            result.Value.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task Get_All_Count_Should_Be_Four()
        {
            // Arrange
            var handler = new GetAllPartnersHandler(_mockRepository.Object, _mapper, _mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetAllPartnersQuery(), CancellationToken.None);

            // Assert
            result.Value.Count().Should().Be(4);
        }

        [Fact]
        public async Task Get_All_Should_Be_Type_List_PartnerDTO()
        {
            // Arrange
            var handler = new GetAllPartnersHandler(_mockRepository.Object, _mapper, _mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetAllPartnersQuery(), CancellationToken.None);

            // Assert
            result.Value.Should().BeOfType<List<PartnerDTO>>();
        }
    }
}
