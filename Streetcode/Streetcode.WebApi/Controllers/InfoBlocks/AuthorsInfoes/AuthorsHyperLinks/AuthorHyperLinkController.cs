using Microsoft.AspNetCore.Mvc;
using Streetcode.BLL.Dto.InfoBlocks.AuthorsInfoes.AuthorsHyperLinks;
using Streetcode.BLL.MediatR.InfoBlocks.AuthorsInfoes.AuthorsHyperLinks.Create;
using Streetcode.BLL.MediatR.InfoBlocks.AuthorsInfoes.AuthorsHyperLinks.Delete;
using Streetcode.BLL.MediatR.InfoBlocks.AuthorsInfoes.AuthorsHyperLinks.GetAll;
using Streetcode.BLL.MediatR.InfoBlocks.AuthorsInfoes.AuthorsHyperLinks.GetById;
using Streetcode.BLL.MediatR.InfoBlocks.AuthorsInfoes.AuthorsHyperLinks.Update;

namespace Streetcode.WebApi.Controllers.InfoBlocks.AuthorsInfoes.AuthorsHyperLinks
{
    public class AuthorHyperLinkController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AuthorsHyperLinkDto authorHyperLink)
        {
            return HandleResult(await Mediator.Send(new CreateAuthorsHyperLinkCommand(authorHyperLink)));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return HandleResult(await Mediator.Send(new DeleteAuthorsHyperLinkCommand(id)));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return HandleResult(await Mediator.Send(new GetAuthorsHyperLinksByIdQuery(id)));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return HandleResult(await Mediator.Send(new GetAllAuthorsHyperLinksQuery()));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] AuthorsHyperLinkDto authorHyperLink)
        {
            return HandleResult(await Mediator.Send(new UpdateAuthorsHyperLinkCommand(authorHyperLink)));
        }
    }
}
