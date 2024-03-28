using AutoMapper;
using FluentResults;
using MediatR;
using Streetcode.BLL.Dto.Streetcode;
using Streetcode.BLL.Interfaces.Logging;
using Streetcode.DAL.Entities.Streetcode;
using Streetcode.DAL.Repositories.Interfaces.Base;

namespace Streetcode.BLL.MediatR.Streetcode.Streetcode.Create
{
    internal class CreateStreetcodeCommandHandler : IRequestHandler<CreateStreetcodeCommand, Result<StreetcodeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly ILoggerService _logger;

        public CreateStreetcodeCommandHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper, ILoggerService logger)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<StreetcodeDto>> Handle(CreateStreetcodeCommand request, CancellationToken cancellationToken)
        {
            var newStreetCode = _mapper.Map<StreetcodeContent>(request.StreetcodeDto);

            if (newStreetCode is null)
            {
                const string errorMsg = $"Can not map {nameof(request.StreetcodeDto)} to {nameof(StreetcodeContent)} in {nameof(CreateStreetcodeCommandHandler)}";
                _logger.LogError(request, errorMsg);
                return Result.Fail(new Error(errorMsg));
            }

            await _repositoryWrapper.StreetcodeRepository.CreateAsync(newStreetCode);

            var isCreatedSuccessfully = await _repositoryWrapper.SaveChangesAsync() > 0;

            var createdStreetcode = _mapper.Map<StreetcodeDto>(newStreetCode);

            if (isCreatedSuccessfully)
            {
                return Result.Ok(createdStreetcode);
            }
            else
            {
                const string errorMsg = "Failed to create a streetcode.";
                _logger.LogError(request, errorMsg);
                return Result.Fail(new Error(errorMsg));
            }
        }
    }
}
