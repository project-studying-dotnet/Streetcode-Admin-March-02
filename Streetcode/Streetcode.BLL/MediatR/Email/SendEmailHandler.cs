using FluentResults;
using MediatR;
using Streetcode.BLL.Interfaces.Email;
using Streetcode.BLL.Interfaces.Logging;
using Streetcode.DAL.Entities.AdditionalContent.Email;

namespace Streetcode.BLL.MediatR.Email
{
    public class SendEmailHandler : IRequestHandler<SendEmailCommand, Result<Unit>>
    {
        private readonly IEmailService _emailService;
        private readonly ILoggerService _logger;

        public SendEmailHandler(IEmailService emailService, ILoggerService logger)
        {
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<Unit>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
<<<<<<< HEAD
            var message = new Message(new string[] { "streetcodeua@gmail.com" }, request.Email.From, "FeedBack", request.Email.Content);
=======
            var message = new Message(new string[] { "[To]" }, request.Email.From, "FeedBack", request.Email.Content);
>>>>>>> f2bda5e06c2000983237b488a290114777f19fcc
            bool isResultSuccess = await _emailService.SendEmailAsync(message);

            if(isResultSuccess)
            {
                return Result.Ok(Unit.Value);
            }
            else
            {
                const string errorMsg = $"Failed to send email message";
                _logger.LogError(request, errorMsg);
                return Result.Fail(new Error(errorMsg));
            }
        }
    }
}
