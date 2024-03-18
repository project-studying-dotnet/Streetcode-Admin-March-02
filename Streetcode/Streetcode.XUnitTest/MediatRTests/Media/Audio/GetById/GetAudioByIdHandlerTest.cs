using AutoMapper;
using FluentAssertions;
using Moq;
using Streetcode.BLL.Interfaces.BlobStorage;
using Streetcode.BLL.Interfaces.Logging;
using Streetcode.BLL.Mapping.Media;
using Streetcode.BLL.MediatR.Media.Art.GetById;
using Streetcode.BLL.MediatR.Media.Audio.GetAll;
using Streetcode.BLL.MediatR.Media.Audio.GetById;
using Streetcode.DAL.Repositories.Interfaces.Base;
using Streetcode.XUnitTest.MediatRTests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Streetcode.XUnitTest.MediatRTests.Media.Audio.GetById
{
    // TESTED SUCCESSFULLY
    // BLL -> MediatR -> Media -> Audio -> GetById
    public class GetAudioByIdHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IRepositoryWrapper> _mockRepository;
        private readonly Mock<ILoggerService> _mockLogger;
        private readonly Mock<IBlobService> _mockBlob;

        public GetAudioByIdHandlerTest()
        {
            _mockRepository = RepositoryMocker.GetAudiosRepositoryMock();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<AudioProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _mockLogger = new Mock<ILoggerService>();

            _mockBlob = new Mock<IBlobService>();
        }

        [Fact]
        public async Task Get_By_Id_Not_Null_Test()
        {
            //Arrange
            var handler = new GetAudioByIdHandler(_mockRepository.Object, _mapper, _mockBlob.Object, _mockLogger.Object);

            //Act
            var result = await handler.Handle(new GetAudioByIdQuery(2), CancellationToken.None);

            //Assert        
            result.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task Get_By_Id_First_Should_Be_First_Test()
        {
            //Arrange
            var handler = new GetAudioByIdHandler(_mockRepository.Object, _mapper, _mockBlob.Object, _mockLogger.Object);

            //Act
            var result = await handler.Handle(new GetAudioByIdQuery(1), CancellationToken.None);

            //Assert        
            result.Value.MimeType.Should().Be("First mime type");
        }

        [Fact]
        public async Task Get_By_Id_Second_Should_Not_Be_Fourth_Test()
        {
            //Arrange
            var handler = new GetAudioByIdHandler(_mockRepository.Object, _mapper, _mockBlob.Object, _mockLogger.Object);

            //Act
            var result = await handler.Handle(new GetAudioByIdQuery(2), CancellationToken.None);

            //Assert        
            result.Value.MimeType.Should().NotBe("Fourth mime type");
        }
    }
}
