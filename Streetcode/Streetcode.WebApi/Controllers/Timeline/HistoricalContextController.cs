using Microsoft.AspNetCore.Mvc;
using Streetcode.BLL.Dto.Timeline;
using Streetcode.BLL.MediatR.Timeline.HistoricalContext.Create;
using Streetcode.BLL.MediatR.Timeline.HistoricalContext.GetAll;

namespace Streetcode.WebApi.Controllers.Timeline
{
    public class HistoricalContextController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return HandleResult(await Mediator.Send(new GetAllHistoricalContextQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] HistoricalContextDto historicalContext)
        {
            return HandleResult(await Mediator.Send(new CreateHistoricalContextCommand(historicalContext)));
        }
    }
}
