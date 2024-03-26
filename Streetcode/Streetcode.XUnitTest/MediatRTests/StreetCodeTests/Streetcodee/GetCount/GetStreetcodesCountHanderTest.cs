namespace Streetcode.XUnitTest.MediatRTests.StreetCodeTests.Streetcodee.GetCount
{
    using System;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Streetcode;
    using Streetcode.BLL.MediatR.Streetcode.Streetcode.GetCount;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    public class GetStreetcodesCountHanderTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        public GetStreetcodesCountHanderTest()
        {
            this.mockRepository = RepositoryMocker.GetAllStreetcodes();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<StreetcodeProfile>();
            });

            this.mapper = mapperConfig.CreateMapper();

            this.mockLogger = new Mock<ILoggerService>();
        }

        [Fact]
        public async Task Result_GetStreetcodesCount_Test()
        {
            var handler = new GetStreetcodesCountHander(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            var result = await handler.Handle(new GetStreetcodesCountQuery(), CancellationToken.None);

            result.Value.Should().Be(3);
        }
    }
}