using AutoMapper;
using FluentAssertions;
using Moq;
using Repositories.Interfaces;
using Streetcode.BLL.DTO.Media.Art;
using Streetcode.BLL.Interfaces.Logging;
using Streetcode.BLL.Mapping.Media.Images;
using Streetcode.BLL.MediatR.Media.Art.GetAll;
using Streetcode.DAL.Repositories.Interfaces.Base;
using Streetcode.XUnitTest.MediatRTests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Streetcode.XUnitTest.MediatRTests.Media.Art.GetAll
{
    //TESTED SUCCESSFULLY
    //BLL -> MediatR -> Media -> Art -> GetAll
    public class GetAllArtsHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IRepositoryWrapper> _mockRepository;
        private readonly Mock<ILoggerService> _mockLogger;

        public GetAllArtsHandlerTest()
        {
            _mockRepository = RepositoryMocker.GetArtRepositoryMock();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<ArtProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _mockLogger = new Mock<ILoggerService>();
        }

        [Fact]
        public async Task Get_All_Not_Null_Or_Empty_Test()
        {
            //Arrange
            var handler = new GetAllArtsHandler(_mockRepository.Object, _mapper, _mockLogger.Object);

            //Act
            var result = await handler.Handle(new GetAllArtsQuery(), CancellationToken.None);

            //Assert        
            result.Value.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task Get_All_Count_Should_Be_Four()
        {
            //Arrange
            var handler = new GetAllArtsHandler(_mockRepository.Object, _mapper, _mockLogger.Object);

            //Act
            var result = await handler.Handle(new GetAllArtsQuery(), CancellationToken.None);

            //Assert        
            result.Value.Count().Should().Be(4);
        }

        [Fact]
        public async Task Get_All_Should_Be_Type_List_ArtDTO()
        {
            //Arrange
            var handler = new GetAllArtsHandler(_mockRepository.Object, _mapper, _mockLogger.Object);

            //Act
            var result = await handler.Handle(new GetAllArtsQuery(), CancellationToken.None);

            //Assert        
            result.Value.Should().BeOfType<List<ArtDTO>>();
        }
    }
}
