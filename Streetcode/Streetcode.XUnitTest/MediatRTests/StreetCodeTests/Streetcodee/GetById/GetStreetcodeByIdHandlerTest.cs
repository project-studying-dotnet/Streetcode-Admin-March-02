namespace Streetcode.XUnitTest.MediatRTests.StreetCodeTests.Streetcodee.GetById
{
    using System;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Dto.AdditionalContent.Filter;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Streetcode;
    using Streetcode.BLL.MediatR.Streetcode.Streetcode.GetByFilter;
    using Streetcode.BLL.MediatR.Streetcode.Streetcode.GetById;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    public class GetStreetcodeByIdHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        public GetStreetcodeByIdHandlerTest()
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
        public async Task Result_GetStreetcodesById_Test()
        {
            var handler = new GetStreetcodeByIdHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            var result = await handler.Handle(new GetStreetcodeByIdQuery(2), CancellationToken.None);


            //result.Value.Id.Should().Be(2);

            Assert.Equal(2, result.Value.Id);
        }
    }
}