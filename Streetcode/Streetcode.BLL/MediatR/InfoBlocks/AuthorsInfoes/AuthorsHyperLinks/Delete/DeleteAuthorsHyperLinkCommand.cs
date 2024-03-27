using FluentResults;
using MediatR;

namespace Streetcode.BLL.MediatR.InfoBlocks.AuthorsInfoes.AuthorsHyperLinks.Delete
{
    public record DeleteAuthorsHyperLinkCommand(int Id) : IRequest<Result<Unit>>;
}
