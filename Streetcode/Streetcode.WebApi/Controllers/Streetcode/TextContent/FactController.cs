using Microsoft.AspNetCore.Mvc;
using Streetcode.BLL.Dto.Streetcode.TextContent.Fact;
using Streetcode.BLL.MediatR.Fact.ResetOrderNumbers;
using Streetcode.BLL.MediatR.Fact.Update;
using Streetcode.BLL.MediatR.Streetcode.Fact.Create;
using Streetcode.BLL.MediatR.Streetcode.Fact.Delete;
using Streetcode.BLL.MediatR.Streetcode.Fact.GetAll;
using Streetcode.BLL.MediatR.Streetcode.Fact.GetById;
using Streetcode.BLL.MediatR.Streetcode.Fact.GetByStreetcodeId;

namespace Streetcode.WebApi.Controllers.Streetcode.TextContent;

public class FactController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return HandleResult(await Mediator.Send(new GetAllFactsQuery()));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        return HandleResult(await Mediator.Send(new GetFactByIdQuery(id)));
    }

    [HttpGet("{streetcodeId:int}")]
    public async Task<IActionResult> GetByStreetcodeId([FromRoute] int streetcodeId)
    {
        return HandleResult(await Mediator.Send(new GetFactByStreetcodeIdQuery(streetcodeId)));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] FactBaseDto position)
    {
        return HandleResult(await Mediator.Send(new CreateFactCommand(position)));
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] FactDto fact)
    {
        return HandleResult(await Mediator.Send(new UpdateFactCommand(fact)));
    }

    [HttpPut("{streetcodeId:int}")]
    public async Task<IActionResult> UpdateOrderNumbers([FromRoute] int streetcodeId)
    {
        return HandleResult(await Mediator.Send(new ResetFactOrderNumbersCommand(streetcodeId)));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return HandleResult(await Mediator.Send(new DeleteFactCommand(id)));
    }
}