using System;
using AutoMapper;
using FluentAssertions;
using Moq;
using Streetcode.BLL.Interfaces.Logging;
using Streetcode.BLL.Mapping.Streetcode.TextContent;
using Streetcode.BLL.MediatR.Streetcode.Fact.GetById;
using Streetcode.BLL.MediatR.Streetcode.Fact.GetByStreetcodeId;
using Streetcode.DAL.Repositories.Interfaces.Base;
using Streetcode.XUnitTest.MediatRTests.Mocks;
using Xunit;

namespace Streetcode.XUnitTest.MediatRTests.StreetCodeTests.Fact.GetByStreetcodeIdTest
{
    public class GetFactByStreetcodeIdHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        public GetFactByStreetcodeIdHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetAllFacts();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<FactProfile>();
            });

            this.mapper = mapperConfig.CreateMapper();

            this.mockLogger = new Mock<ILoggerService>();
        }

        [Fact]
        public async Task Result_GetByStreetcodeIdShouldNotBeNull_Test()
        {
            var handler = new GetFactByStreetcodeIdHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            var result = await handler.Handle(new GetFactByStreetcodeIdQuery(2), CancellationToken.None);

            result.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task Result_GetByStreetcodeIdShouldBeSecond_Test()
        {
            var handler = new GetFactByStreetcodeIdHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            var result = await handler.Handle(new GetFactByStreetcodeIdQuery(2), CancellationToken.None);

            result.Value.ElementAt(2).Id.Should().Be(3);
        }
    }
}