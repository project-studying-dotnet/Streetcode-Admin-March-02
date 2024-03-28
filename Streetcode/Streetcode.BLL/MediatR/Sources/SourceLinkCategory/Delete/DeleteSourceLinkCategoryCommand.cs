using FluentResults;
using MediatR;

namespace Streetcode.BLL.MediatR.Sources.SourceLinkCategory.Delete
{
    public record DeleteSourceLinkCategoryCommand(int id) : IRequest<Result<Unit>>;
}
