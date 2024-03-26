using FluentValidation;

namespace Streetcode.BLL.MediatR.Newss.Create
{
    internal class CreateNewsCommandValidator : AbstractValidator<CreateNewsCommand>
    {
        private readonly int _maxTitleLength;
        private readonly int _maxURLLength;
        public CreateNewsCommandValidator()
        {
            _maxTitleLength = 150;
            _maxURLLength = 100;

            RuleFor(command => command.newNews.Title)
                .NotEmpty()
                .WithMessage("Title is required.")
                .MaximumLength(_maxTitleLength)
                .WithMessage($"Title length should not be longer than {_maxTitleLength} symbols.");

            RuleFor(command => command.newNews.Text)
               .NotEmpty()
               .WithMessage("Text is required.");

            RuleFor(command => command.newNews.URL)
               .NotEmpty()
               .WithMessage("URL is required.")
               .MaximumLength(_maxURLLength)
               .WithMessage($"URL length should not be longer than {_maxURLLength} symbols.");

            RuleFor(command => command.newNews.CreationDate)
                .NotEmpty()
                .WithMessage("Creation date is required.");
        }
    }
}
