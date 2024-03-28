using FluentResults;
using MediatR;
using Streetcode.BLL.Dto.Sources;

namespace Streetcode.BLL.MediatR.Sources.StreetcodeCategoryContent.GetCategoryContentsByStreetcodeIdAndSourceLinkCategoryId
{
    public record GetAllCategoryContentsByStreetcodeIdAndSourceLinkCategoryIdQuery(int streetcodeId, int categoryId) : IRequest<Result<IEnumerable<StreetcodeCategoryContentDto>>>;
}
