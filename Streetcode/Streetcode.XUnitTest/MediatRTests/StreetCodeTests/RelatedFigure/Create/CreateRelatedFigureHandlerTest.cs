namespace Streetcode.XUnitTest.MediatRTests.StreetCodeTests.RelatedFigure.Create
{
    using System;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Streetcode;
    using Streetcode.BLL.MediatR.Streetcode.RelatedFigure.Create;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    public class CreateRelatedFigureHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        public CreateRelatedFigureHandlerTest()
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
        public async Task Result_ShoulBeNull_Test()
        {
            var handler = new CreateRelatedFigureHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            DAL.Entities.Streetcode.RelatedFigure? newRelatedFigure = null;

            var result = await handler.Handle(new CreateRelatedFigureCommand(newRelatedFigure.ObserverId, newRelatedFigure.TargetId), CancellationToken.None);

            result.IsFailed.Should().BeTrue();
        }

        [Fact]
        public async Task Result_ShoulNotBeNull_Test()
        {
            var handler = new CreateRelatedFigureHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            DAL.Entities.Streetcode.RelatedFigure newRelatedFigure = new DAL.Entities.Streetcode.RelatedFigure()
            {
                Observer = new DAL.Entities.Streetcode.StreetcodeContent(),
                ObserverId = 2,
                Target = new DAL.Entities.Streetcode.StreetcodeContent(),
                TargetId = 2,
            };

            var result = await handler.Handle(new CreateRelatedFigureCommand(newRelatedFigure.ObserverId, newRelatedFigure.TargetId), CancellationToken.None);

            result.IsSuccess.Should().BeTrue();
        }
    }
}