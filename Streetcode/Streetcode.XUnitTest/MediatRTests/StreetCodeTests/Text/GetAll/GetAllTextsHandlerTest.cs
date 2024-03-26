namespace Streetcode.XUnitTest.MediatRTests.StreetCodeTests.Text.GetAll
{
    using System;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Streetcode;
    using Streetcode.BLL.Mapping.Streetcode.TextContent;
    using Streetcode.BLL.MediatR.Streetcode.Text.GetAll;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    public class GetAllTextsHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        public GetAllTextsHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetAllTexts();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<TextProfile>();
            });

            this.mapper = mapperConfig.CreateMapper();

            this.mockLogger = new Mock<ILoggerService>();
        }

        [Fact]
        public async Task Result_GetAllTextsNotNull_Test()
        {
            var handler = new GetAllTextsHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            var result = await handler.Handle(new GetAllTextsQuery(), CancellationToken.None);

            result.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task Result_GetAllTextsCount_Test()
        {
            var handler = new GetAllTextsHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            var result = await handler.Handle(new GetAllTextsQuery(), CancellationToken.None);

            result.Value.Count().Should().Be(3);
        }
    }
}