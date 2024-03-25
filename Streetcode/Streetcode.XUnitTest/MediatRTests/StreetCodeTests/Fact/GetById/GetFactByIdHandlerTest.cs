using System;
using AutoMapper;
using FluentAssertions;
using Moq;
using Streetcode.BLL.Interfaces.Logging;
using Streetcode.BLL.Mapping.Streetcode.TextContent;
using Streetcode.BLL.MediatR.Streetcode.Fact.GetAll;
using Streetcode.BLL.MediatR.Streetcode.Fact.GetById;
using Streetcode.DAL.Repositories.Interfaces.Base;
using Streetcode.XUnitTest.MediatRTests.Mocks;
using Xunit;

namespace Streetcode.XUnitTest.MediatRTests.StreetCodeTests.Fact.GetById
{
    public class GetFactByIdHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        public GetFactByIdHandlerTest()
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
        public async Task Result_GetFactByIdHandlerNotNull_Test()
        {
            var handler = new GetFactByIdHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            var result = await handler.Handle(new GetFactByIdQuery(2), CancellationToken.None);

            result.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task Result_GetFactByIdHandlerShouldBeSecond_Test()
        {
            var handler = new GetFactByIdHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            var result = await handler.Handle(new GetFactByIdQuery(2), CancellationToken.None);

            Assert.Equal(2, result.Value.Id);
        }
    }
}