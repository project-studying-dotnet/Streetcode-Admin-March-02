namespace Streetcode.XUnitTest.MediatRTests.Newss.Create
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Dto.AdditionalContent.Coordinates.Types;
    using Streetcode.BLL.Dto.News;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Newss;
    using Streetcode.BLL.MediatR.AdditionalContent.Coordinate.Create;
    using Streetcode.BLL.MediatR.Newss.Create;
    using Streetcode.DAL.Entities.News;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    public class CreateNewsHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        public CreateNewsHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetNewsRepositoryMock();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<NewsProfile>();
            });

            this.mapper = mapperConfig.CreateMapper();

            this.mockLogger = new Mock<ILoggerService>();
        }

        [Fact]
        public async Task Handle_NewsDtoIsNull_IsFailedShouldBeTrue()
        {
            // Arrange
            var handler = new CreateNewsHandler(this.mapper, this.mockRepository.Object, this.mockLogger.Object);
            NewsDto? newsDto = null;
            var streetcodeCoordinate = new CreateNewsCommand(newsDto);

            // Act
            var result = await handler.Handle(streetcodeCoordinate, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
        }

        [Fact]
        public async Task Handle_ValidDto_IsSuccessShouldBeTrue()
        {
            // Arrange
            var handler = new CreateNewsHandler(this.mapper, this.mockRepository.Object, this.mockLogger.Object);
            NewsDto? newsDto = new NewsDto()
            {
                Id = 1,
                Text = "Text1",
                ImageId = 1,
                CreationDate = DateTime.Now,
                Title = "Title1",
                URL = "example.com",
            };
            var streetcodeCoordinate = new CreateNewsCommand(newsDto);

            // Act
            var result = await handler.Handle(streetcodeCoordinate, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
        }
    }
}
