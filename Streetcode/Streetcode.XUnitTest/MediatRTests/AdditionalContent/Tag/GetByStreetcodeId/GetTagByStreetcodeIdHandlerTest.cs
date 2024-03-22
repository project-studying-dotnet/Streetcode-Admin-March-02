namespace Streetcode.XUnitTest.MediatRTests.AdditionalContent.Tag.GetByStreetcodeId
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
    using Streetcode.BLL.DTO.AdditionalContent.Tag;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.AdditionalContent;
    using Streetcode.BLL.MediatR.AdditionalContent.Subtitle.GetByStreetcodeId;
    using Streetcode.BLL.MediatR.AdditionalContent.Tag.GetByStreetcodeId;
    using Streetcode.DAL.Entities.AdditionalContent;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    public class GetTagByStreetcodeIdHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        public GetTagByStreetcodeIdHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetTagRepositoryMock();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<TagProfile>();
            });

            this.mapper = mapperConfig.CreateMapper();

            this.mockLogger = new Mock<ILoggerService>();
        }

        [Fact]
        public async Task Handler_GetByStreetcodeValidId_ResultShouldNotBeNull()
        {
            // Arrange
            var handler = new GetTagByStreetcodeIdHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);
            int validId = 1;
            var request = new GetTagByStreetcodeIdQuery(validId);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task Handler_GetByStreetcodeValidId_ResultShouldBeOfTypeIEnumerableStreetcodeTagDTO()
        {
            // Arrange
            var handler = new GetTagByStreetcodeIdHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);
            int validId = 1;
            var request = new GetTagByStreetcodeIdQuery(validId);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Value.Should().BeOfType<List<StreetcodeTagDTO>>();
        }

        [Fact]
        public async Task Handler_GetByStreetcodeInvalidId_IsFailedShouldBeTrue()
        {
            // Arrange
            var handler = new GetTagByStreetcodeIdHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);
            int invalidId = 10;
            var request = new GetTagByStreetcodeIdQuery(invalidId);

            this.mockRepository.Setup(x => x.StreetcodeTagIndexRepository.GetAllAsync(
                It.IsAny<Expression<Func<StreetcodeTagIndex, bool>>>(),
                It.IsAny<Func<IQueryable<StreetcodeTagIndex>, IIncludableQueryable<StreetcodeTagIndex, object>>>()))
            .Returns(Task.FromResult<IEnumerable<StreetcodeTagIndex>>(null));

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
        }
    }
}
