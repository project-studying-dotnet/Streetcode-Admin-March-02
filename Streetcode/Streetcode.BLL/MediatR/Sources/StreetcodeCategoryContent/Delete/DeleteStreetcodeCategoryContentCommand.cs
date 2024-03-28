using FluentResults;
using MediatR;

namespace Streetcode.BLL.MediatR.Sources.StreetcodeCategoryContent.Delete
{
    public record DeleteStreetcodeCategoryContentCommand(int id) : IRequest<Result<Unit>>;
}
