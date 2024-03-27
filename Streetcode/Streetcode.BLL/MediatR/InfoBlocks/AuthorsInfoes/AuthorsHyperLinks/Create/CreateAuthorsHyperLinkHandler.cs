using AutoMapper;
using FluentResults;
using MediatR;
using Streetcode.BLL.Dto.InfoBlocks.AuthorsInfoes.AuthorsHyperLinks;
using Streetcode.BLL.Interfaces.Logging;
using Streetcode.DAL.Entities.InfoBlocks.AuthorsInfoes.AuthorsHyperLinks;
using Streetcode.DAL.Repositories.Interfaces.Base;

namespace Streetcode.BLL.MediatR.InfoBlocks.AuthorsInfoes.AuthorsHyperLinks.Create
{
    public class CreateAuthorsHyperLinkHandler : IRequestHandler<CreateAuthorsHyperLinkCommand, Result<AuthorsHyperLinkDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly ILoggerService _logger;

        public CreateAuthorsHyperLinkHandler(IMapper mapper, IRepositoryWrapper repositoryWrapper, ILoggerService logger)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _logger = logger;
        }

        public async Task<Result<AuthorsHyperLinkDto>> Handle(CreateAuthorsHyperLinkCommand request, CancellationToken cancellationToken)
        {
            var newAuthorHyperLink = _mapper.Map<AuthorHyperLink>(request.newAuthorHyperLink);

            if (newAuthorHyperLink is null)
            {
                const string errorMsg = "Cannot convert null to author hyper link";
                _logger.LogError(request, errorMsg);
                return Result.Fail(errorMsg);
            }

            var entity = _repositoryWrapper.AuthorHyperLinkRepository.Create(newAuthorHyperLink);

            var resultIsSuccess = await _repositoryWrapper.SaveChangesAsync() > 0;

            if (resultIsSuccess)
            {
                return Result.Ok(_mapper.Map<AuthorsHyperLinkDto>(entity));
            }
            else
            {
                const string errorMsg = "Failed to create an author hyper link";
                _logger.LogError(request, errorMsg);
                return Result.Fail(new Error(errorMsg));
            }
        }
    }
}
