using FluentResults;
using MediatR;
using Streetcode.BLL.Dto.Streetcode;

namespace Streetcode.BLL.MediatR.Streetcode.Streetcode.Create
{
    public record CreateStreetcodeCommand(StreetcodeDto StreetcodeDto) : IRequest<Result<StreetcodeDto>>;
}
