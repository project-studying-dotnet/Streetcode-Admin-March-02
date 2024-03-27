using FluentResults;
using MediatR;

namespace Streetcode.BLL.MediatR.InfoBlocks.InfoBlockss.Delete
{
    public record class DeleteInfoBlockCommand(int Id) : IRequest<Result<Unit>>;
}
