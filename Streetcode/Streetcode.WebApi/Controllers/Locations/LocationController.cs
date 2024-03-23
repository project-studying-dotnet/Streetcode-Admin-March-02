using Microsoft.AspNetCore.Mvc;
using Streetcode.BLL.Dto.Locations;

namespace Streetcode.WebApi.Controllers.Locations
{
    public class LocationController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LocationDto location)
        {
            return HandleResult(await Mediator.Send(new BLL.MediatR.Locations.Create.CreateLocationCommand(location)));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return HandleResult(await Mediator.Send(new BLL.MediatR.Locations.Delete.DeleteLocationCommand(id)));
        }
    }
}
