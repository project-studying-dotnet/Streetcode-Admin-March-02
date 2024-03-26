namespace Streetcode.XUnitTest.MediatRTests.StreetCodeTests.Streetcodee.GetByIndex
{
    using System;
    using AutoMapper;
    using Moq;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Streetcode;
    using Streetcode.BLL.MediatR.Streetcode.Streetcode.GetById;
    using Streetcode.BLL.MediatR.Streetcode.Streetcode.GetByIndex;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    public class GetStreetcodeByIndexHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        public GetStreetcodeByIndexHandlerTest()
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
        public async Task Result_GetStreetcodesByIndex_Test()
        {
            var handler = new GetStreetcodeByIndexHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            var result = await handler.Handle(new GetStreetcodeByIndexQuery(2), CancellationToken.None);

            Assert.Equal(2, result.Value.Index);
        }
    }
}