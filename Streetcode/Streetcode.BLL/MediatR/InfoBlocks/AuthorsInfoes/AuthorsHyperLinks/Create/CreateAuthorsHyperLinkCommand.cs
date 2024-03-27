using FluentResults;
using MediatR;
using Streetcode.BLL.Dto.InfoBlocks.AuthorsInfoes.AuthorsHyperLinks;

namespace Streetcode.BLL.MediatR.InfoBlocks.AuthorsInfoes.AuthorsHyperLinks.Create
{
    public record CreateAuthorsHyperLinkCommand(AuthorsHyperLinkDto newAuthorHyperLink) : IRequest<Result<AuthorsHyperLinkDto>>;
}
