namespace Streetcode.XUnitTest.MediatRTests.StreetCodeTests.Streetcodee.GetAll
{
    using System;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Streetcode;
    using Streetcode.BLL.MediatR.Streetcode.Streetcode.GetAll;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    public class GetAllStreetcodesHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        public GetAllStreetcodesHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetStreetcodeRepositoryMock();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<StreetcodeProfile>();
            });

            this.mapper = mapperConfig.CreateMapper();

            this.mockLogger = new Mock<ILoggerService>();
        }

        [Fact]
        public async Task Result_GetAllStreetcodes_Test()
        {
            var handler = new GetAllStreetcodesHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            var result = await handler.Handle(new GetAllStreetcodesQuery(new BLL.Dto.Streetcode.GetAllStreetcodesRequestDto()), CancellationToken.None);

            result.Value.Should().NotBeNull();
        }
    }
}