using System;
using Moq;
using Streetcode.BLL.Interfaces.Text;
using Streetcode.BLL.MediatR.Streetcode.Text.GetParsed;
using Xunit;

namespace Streetcode.XUnitTest.MediatRTests.StreetCodeTests.Text.GetParsed
{
    public class GetParsedTextAdminPreviewHandlerTest
    {
        private readonly Mock<ITextService> textService;

        public GetParsedTextAdminPreviewHandlerTest()
        {
            this.textService = new Mock<ITextService>();
        }

        [Fact]
        public async Task Result_GetParsed_Test()
        {
            var handler = new GetParsedTextAdminPreviewHandler(textService.Object);

            var result = await handler.Handle(new GetParsedTextForAdminPreviewCommand("1TextContent"), CancellationToken.None);

            Assert.Equal("1TextContent", result.Value);
        }
    }
}