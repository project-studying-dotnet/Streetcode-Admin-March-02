namespace Streetcode.XUnitTest.MediatRTests.StreetCodeTests.Streetcodee.GetByFilter
{
    using System;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Dto.AdditionalContent.Filter;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Streetcode;
    using Streetcode.BLL.MediatR.Streetcode.Streetcode.GetAllShort;
    using Streetcode.BLL.MediatR.Streetcode.Streetcode.GetByFilter;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    public class GetStreetcodeByFilterHandlerTest
    {
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        public GetStreetcodeByFilterHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetStreetcodeRepositoryMock();

            this.mockLogger = new Mock<ILoggerService>();
        }

        [Fact]
        public async Task Result_GetAllStreetcodesByFilter_Test()
        {
            var handler = new GetStreetcodeByFilterHandler(this.mockRepository.Object, this.mockLogger.Object);

            var result = await handler.Handle(new GetStreetcodeByFilterQuery(new StreetcodeFilterRequestDto()), CancellationToken.None);

            result.Value.Should().NotBeNull();
        }
    }
}