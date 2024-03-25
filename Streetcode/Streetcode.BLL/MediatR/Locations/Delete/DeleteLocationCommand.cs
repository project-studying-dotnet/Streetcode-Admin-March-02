using FluentResults;
using MediatR;

namespace Streetcode.BLL.MediatR.Locations.Delete
{
    public record DeleteLocationCommand(int id) : IRequest<Result<Unit>>;
}
