using AutoMapper;
using FluentAssertions;
using Moq;
using Streetcode.BLL.Dto.Media.Art;
using Streetcode.BLL.Dto.Media.Images;
using Streetcode.BLL.Interfaces.BlobStorage;
using Streetcode.BLL.Interfaces.Logging;
using Streetcode.BLL.Mapping.Media.Images;
using Streetcode.BLL.MediatR.Media.Image.GetById;
using Streetcode.BLL.MediatR.Media.StreetcodeArt.GetByStreetcodeId;
using Streetcode.DAL.Repositories.Interfaces.Base;
using Streetcode.XUnitTest.MediatRTests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Streetcode.XUnitTest.MediatRTests.Media.StreetcodeArt.GetByStreetcodeId
{
    /// <summary>
    /// Tested successfully.
    /// </summary>
    public class GetStreetcodeArtByStreetcodeIdHandlerTest
    {
        private readonly Mock<IMapper> mockMapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;
        private readonly Mock<IBlobService> mockBlob;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetStreetcodeArtByStreetcodeIdHandlerTest"/> class.
        /// </summary>
        public GetStreetcodeArtByStreetcodeIdHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetStreetcodeArtRepositoryMock();

            this.mockMapper = new Mock<IMapper>();

            this.mockLogger = new Mock<ILoggerService>();

            this.mockBlob = new Mock<IBlobService>();
        }

        /// <summary>
        /// Get by id not null test.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetByIdNotNullTest()
        {
            // Arrange
            var handler = new GetStreetcodeArtByStreetcodeIdHandler(this.mockRepository.Object, this.mockMapper.Object, this.mockBlob.Object, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetStreetcodeArtByStreetcodeIdQuery(1), CancellationToken.None);

            // Assert
            result.Value.Should().NotBeNull();
        }

        /// <summary>
        /// Get by id collection size should be zero.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetByIdSizeShoulBeZero()
        {
            // Arrange
            var handler = new GetStreetcodeArtByStreetcodeIdHandler(this.mockRepository.Object, this.mockMapper.Object, this.mockBlob.Object, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetStreetcodeArtByStreetcodeIdQuery(1), CancellationToken.None);

            // Assert
            result.Value.Count().Should().Be(0);
        }
    }
}
