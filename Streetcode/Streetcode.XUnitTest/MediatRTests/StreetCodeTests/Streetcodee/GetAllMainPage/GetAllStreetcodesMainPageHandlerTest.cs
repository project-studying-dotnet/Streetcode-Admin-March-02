using System;
using AutoMapper;
using FluentAssertions;
using Moq;
using Streetcode.BLL.Interfaces.Logging;
using Streetcode.BLL.Mapping.Streetcode;
using Streetcode.BLL.MediatR.Streetcode.Streetcode.GetAll;
using Streetcode.BLL.MediatR.Streetcode.Streetcode.GetAllMainPage;
using Streetcode.DAL.Repositories.Interfaces.Base;
using Streetcode.XUnitTest.MediatRTests.Mocks;
using Xunit;

namespace Streetcode.XUnitTest.MediatRTests.StreetCodeTests.Streetcodee.GetAllMainPage
{
    public class GetAllStreetcodesMainPageHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        public GetAllStreetcodesMainPageHandlerTest()
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
            var handler = new GetAllStreetcodesMainPageHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            var result = await handler.Handle(new BLL.MediatR.Streetcode.Streetcode.GetAllStreetcodesMainPage.GetAllStreetcodesMainPageQuery(), CancellationToken.None);

            result.Value.Should().NotBeNull();
        }
    }
}