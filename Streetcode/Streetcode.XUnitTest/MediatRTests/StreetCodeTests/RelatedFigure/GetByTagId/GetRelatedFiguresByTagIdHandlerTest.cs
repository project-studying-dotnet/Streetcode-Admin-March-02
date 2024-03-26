namespace Streetcode.XUnitTest.MediatRTests.StreetCodeTests.RelatedFigure.GetByTagId
{
    using System;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Streetcode;
    using Streetcode.BLL.MediatR.Streetcode.RelatedFigure.GetByTagId;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    public class GetRelatedFiguresByTagIdHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        public GetRelatedFiguresByTagIdHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetAllRelatedFigures();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<RelatedFigureProfile>();
            });

            this.mapper = mapperConfig.CreateMapper();

            this.mockLogger = new Mock<ILoggerService>();
        }

        [Fact]
        public async Task Result_GetByTagIdShouldNotBeNull_Test()
        {
            var handler = new GetRelatedFiguresByTagIdHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            var result = await handler.Handle(new GetRelatedFiguresByTagIdQuery(2), CancellationToken.None);

            result.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task Result_GetByTagIdShouldBeSecond_Test()
        {
            var handler = new GetRelatedFiguresByTagIdHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            var result = await handler.Handle(new GetRelatedFiguresByTagIdQuery(2), CancellationToken.None);

            result.Value.ElementAt(1).Tags.FirstOrDefault(x => x.Id == 2);
        }
    }
}