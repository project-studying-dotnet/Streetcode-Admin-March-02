using AutoMapper;
using FluentAssertions;
using Moq;
using Streetcode.BLL.Dto.News;
using Streetcode.BLL.Dto.Sources;
using Streetcode.BLL.Interfaces.Logging;
using Streetcode.BLL.Mapping.Sources;
using Streetcode.BLL.MediatR.Newss.Create;
using Streetcode.BLL.MediatR.Sources.SourceLinkCategory;
using Streetcode.BLL.MediatR.Sources.SourceLinkCategory.Create;
using Streetcode.DAL.Repositories.Interfaces.Base;
using Streetcode.XUnitTest.MediatRTests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Streetcode.XUnitTest.MediatRTests.Sources.SourceLinkCategory.Create
{
    public class CreateSourceLinkCategoryHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        public CreateSourceLinkCategoryHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetSourceRepositoryMock();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<SourceLinkCategoryProfile>();
                c.AddProfile<SourceLinkSubCategoryProfile>();
                c.AddProfile<StreetcodeCategoryContentProfile>();
            });

            this.mapper = mapperConfig.CreateMapper();

            this.mockLogger = new Mock<ILoggerService>();
        }

        [Fact]
        public async Task Handle_SourceLinkDtoIsNull_IsFailedShouldBeTrue()
        {
            // Arrange
            var handler = new CreateSourceLinkCategoryHandler(this.mapper, this.mockRepository.Object, this.mockLogger.Object);
            SourceLinkCategoryDto? sourceLinkDto = null;
            var request = new CreateSourceLinkCategoryCommand(sourceLinkDto);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
        }

        [Fact]
        public async Task Handle_ValidDto_IsSuccessShouldBeTrue()
        {
            // Arrange
            var handler = new CreateSourceLinkCategoryHandler(this.mapper, this.mockRepository.Object, this.mockLogger.Object);
            SourceLinkCategoryDto? sourceLinkDto = new SourceLinkCategoryDto()
            {
                Id = 1,
                ImageId = 1,
                Title = "Test",
            };
            var request = new CreateSourceLinkCategoryCommand(sourceLinkDto);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
        }
    }
}
