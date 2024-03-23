using FluentResults;
using MediatR;
using Streetcode.BLL.Dto.Locations;

namespace Streetcode.BLL.MediatR.Locations.Create
{
    public record CreateLocationCommand(LocationDto newLocation) : IRequest<Result<LocationDto>>;
}
