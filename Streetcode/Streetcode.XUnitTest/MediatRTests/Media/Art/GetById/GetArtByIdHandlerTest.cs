using AutoMapper;
using FluentAssertions;
using Moq;
using Streetcode.BLL.Interfaces.Logging;
using Streetcode.BLL.Mapping.Media.Images;
using Streetcode.BLL.MediatR.Media.Art.GetAll;
using Streetcode.BLL.MediatR.Media.Art.GetById;
using Streetcode.DAL.Repositories.Interfaces.Base;
using Streetcode.XUnitTest.MediatRTests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Streetcode.XUnitTest.MediatRTests.Media.Art.GetById
{
    //TESTED SUCCESSFULLY
    //BLL -> MediatR -> Media -> Art -> GetById
    public class GetArtByIdHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IRepositoryWrapper> _mockRepository;
        private readonly Mock<ILoggerService> _mockLogger;

        public GetArtByIdHandlerTest()
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
        public async Task Get_By_Id_Not_Null_Test()
        {
            //Arrange
            var handler = new GetArtByIdHandler(_mockRepository.Object, _mapper, _mockLogger.Object);

            //Act
            var result = await handler.Handle(new GetArtByIdQuery(1), CancellationToken.None);

            //Assert        
            result.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task Get_By_Id_First_Should_Be_First_Test()
        {
            //Arrange
            var handler = new GetArtByIdHandler(_mockRepository.Object, _mapper, _mockLogger.Object);

            //Act
            var result = await handler.Handle(new GetArtByIdQuery(1), CancellationToken.None);

            //Assert        
            result.Value.Description.Should().Be("First description");
        }

        [Fact]
        public async Task Get_By_Id_Second_Should_Not_Be_Fourth_Test()
        {
            //Arrange
            var handler = new GetArtByIdHandler(_mockRepository.Object, _mapper, _mockLogger.Object);

            //Act
            var result = await handler.Handle(new GetArtByIdQuery(2), CancellationToken.None);

            //Assert        
            result.Value.Description.Should().NotBe("Fourth description");
        }
    }
}
