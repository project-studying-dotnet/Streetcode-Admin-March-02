using FluentResults;
using MediatR;
using Streetcode.BLL.Dto.InfoBlocks.AuthorsInfoes.AuthorsHyperLinks;

namespace Streetcode.BLL.MediatR.InfoBlocks.AuthorsInfoes.AuthorsHyperLinks.GetById
{
    public record GetAuthorsHyperLinksByIdQuery(int Id) : IRequest<Result<AuthorsHyperLinkDto>>;
}
