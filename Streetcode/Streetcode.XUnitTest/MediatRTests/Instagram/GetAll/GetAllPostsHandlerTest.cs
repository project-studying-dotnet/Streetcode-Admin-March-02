﻿namespace Streetcode.XUnitTest.MediatRTests.Instagram.GetAll
{
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Interfaces.Instagram;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.MediatR.Instagram.GetAll;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    public class GetAllPostsHandlerTest
    {
        private readonly Mock<IInstagramService> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        public GetAllPostsHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetInstagramPostsMock();

            this.mockLogger = new Mock<ILoggerService>();
        }

        [Fact]
        public async Task Get_All_Not_Null_Or_Empty_Test()
        {
            var handler = new GetAllPostsHandler(this.mockRepository.Object, this.mockLogger.Object);

            var result = await handler.Handle(new GetAllPostsQuery(), CancellationToken.None);

            result.Value.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task Get_All_Count_Should_Be_Four()
        {
            var handler = new GetAllPostsHandler(this.mockRepository.Object, this.mockLogger.Object);

            var result = await handler.Handle(new GetAllPostsQuery(), CancellationToken.None);

            result.Value.Count().Should().Be(4);
        }
    }
}