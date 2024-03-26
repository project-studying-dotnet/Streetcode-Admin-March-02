namespace Streetcode.XUnitTest.MediatRTests.StreetCodeTests.RelatedTerm.Update
{
    using System;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Dto.Streetcode.TextContent;
    using Streetcode.BLL.Mapping.Streetcode.TextContent;
    using Streetcode.BLL.MediatR.Streetcode.RelatedTerm.GetAllByTermId;
    using Streetcode.BLL.MediatR.Streetcode.RelatedTerm.Update;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    public class UpdateRelatedTermHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;

        public UpdateRelatedTermHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetAllRelatedTerms();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<RelatedTermProfile>();
            });

            this.mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task Result_GetByTermIdShouldNotBeNull_Test()
        {
            var handler = new UpdateRelatedTermHandler(this.mapper, this.mockRepository.Object);

            var relatedTermDtoTest = new RelatedTermDto()
            {
                Id = 1,
                Word = "1Word",
                TermId = 1,
            };

            var result = await handler.Handle(new UpdateRelatedTermCommand(1, relatedTermDtoTest), CancellationToken.None);

            result.Value.Should().NotBeNull();
        }
    }
}