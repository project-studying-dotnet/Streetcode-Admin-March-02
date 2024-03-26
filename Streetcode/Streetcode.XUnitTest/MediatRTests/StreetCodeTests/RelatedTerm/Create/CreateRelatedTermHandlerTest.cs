namespace Streetcode.XUnitTest.MediatRTests.StreetCodeTests.RelatedTerm.Create
{
    using System;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Dto.Streetcode.TextContent;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Streetcode.TextContent;
    using Streetcode.BLL.MediatR.Streetcode.RelatedTerm.Create;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    public class CreateRelatedTermHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        public CreateRelatedTermHandlerTest()
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
        public async Task Result_ShoulBeNull_Test()
        {
            var handler = new CreateRelatedTermHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            RelatedTermDto? newRelatedTerm = null;

            var result = await handler.Handle(new CreateRelatedTermCommand(newRelatedTerm), CancellationToken.None);

            result.IsFailed.Should().BeTrue();
        }

        [Fact]
        public async Task Result_ShoulNotBeNull_Test()
        {
            var handler = new CreateRelatedTermHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            RelatedTermDto? newRelatedTerm = new RelatedTermDto()
            {
                Id = 1,
                Word = "Word",
                TermId = 1,
            };

            var result = await handler.Handle(new CreateRelatedTermCommand(newRelatedTerm), CancellationToken.None);

            result.IsSuccess.Should().BeTrue();
        }
    }
}