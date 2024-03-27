using AutoMapper;
using FluentResults;
using MediatR;
using Streetcode.BLL.Dto.InfoBlocks.Articles;
using Streetcode.BLL.Dto.InfoBlocks.AuthorsInfoes.AuthorsHyperLinks;
using Streetcode.BLL.Interfaces.Logging;
using Streetcode.DAL.Repositories.Interfaces.Base;

namespace Streetcode.BLL.MediatR.InfoBlocks.AuthorsInfoes.AuthorsHyperLinks.GetAll
{
    public class GetAllAuthorsHyperLinksHandler : IRequestHandler<GetAllAuthorsHyperLinksQuery, Result<IEnumerable<AuthorsHyperLinkDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly ILoggerService _logger;

        public GetAllAuthorsHyperLinksHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper, ILoggerService logger)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<IEnumerable<AuthorsHyperLinkDto>>> Handle(GetAllAuthorsHyperLinksQuery request, CancellationToken cancellationToken)
        {
            var authorsHyperLinks = await _repositoryWrapper.AuthorHyperLinkRepository.GetAllAsync();

            if (authorsHyperLinks is null)
            {
                const string errorMsg = $"Cannot find any authors hyper links";

                _logger.LogError(request, errorMsg);

                return Result.Fail(new Error(errorMsg));
            }

            return Result.Ok(_mapper.Map<IEnumerable<AuthorsHyperLinkDto>>(authorsHyperLinks));
        }
    }
}
