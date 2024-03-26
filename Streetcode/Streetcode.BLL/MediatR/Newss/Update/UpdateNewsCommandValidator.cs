using FluentValidation;

namespace Streetcode.BLL.MediatR.Newss.Update
{
    internal class UpdateNewsCommandValidator : AbstractValidator<UpdateNewsCommand>
    {
        private readonly int _maxTitleLength;
        private readonly int _maxURLLength;
        public UpdateNewsCommandValidator()
        {
            _maxTitleLength = 150;
            _maxURLLength = 100;

            RuleFor(command => command.news.Title)
                .NotEmpty()
                .WithMessage("Title is required.")
                .MaximumLength(_maxTitleLength)
                .WithMessage($"Title length should not be longer than {_maxTitleLength} symbols.");

            RuleFor(command => command.news.Text)
               .NotEmpty()
               .WithMessage("Text is required.");

            RuleFor(command => command.news.URL)
               .NotEmpty()
               .WithMessage("URL is required.")
               .MaximumLength(_maxURLLength)
               .WithMessage($"URL length should not be longer than {_maxURLLength} symbols.");

            RuleFor(command => command.news.CreationDate)
                .NotEmpty()
                .WithMessage("Creation date is required.");
        }
    }
}
