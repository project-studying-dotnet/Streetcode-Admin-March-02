using FluentResults;
using MediatR;
using Streetcode.BLL.Dto.Sources;

namespace Streetcode.BLL.MediatR.Sources.SourceLinkCategory.Update
{
    public record UpdateSourceLinkCategoryCommand(SourceLinkCategoryDto sourceLinkCategoryDto) : IRequest<Result<SourceLinkCategoryDto>>;
}
