namespace Streetcode.XUnitTest.MediatRTests.StreetCodeTests.RelatedTerm.GetAllByTermId
{
    using System;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Streetcode.TextContent;
    using Streetcode.BLL.MediatR.Streetcode.RelatedFigure.GetByTagId;
    using Streetcode.BLL.MediatR.Streetcode.RelatedTerm.GetAllByTermId;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    public class GetAllRelatedTermsByTermIdHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        public GetAllRelatedTermsByTermIdHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetAllRelatedTerms();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<RelatedTermProfile>();
            });

            this.mapper = mapperConfig.CreateMapper();

            this.mockLogger = new Mock<ILoggerService>();
        }

        [Fact]
        public async Task Result_GetByTermIdShouldNotBeNull_Test()
        {
            var handler = new GetAllRelatedTermsByTermIdHandler(this.mapper, this.mockRepository.Object, this.mockLogger.Object);

            var result = await handler.Handle(new GetAllRelatedTermsByTermIdQuery(2), CancellationToken.None);

            result.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task Result_GetByTagIdShouldBeSecond_Test()
        {
            var handler = new GetAllRelatedTermsByTermIdHandler(this.mapper, this.mockRepository.Object, this.mockLogger.Object);

            var result = await handler.Handle(new GetAllRelatedTermsByTermIdQuery(2), CancellationToken.None);

            result.Value.ElementAt(1).TermId.Should().Be(2);
        }
    }
}