using FluentValidation;

namespace Streetcode.BLL.MediatR.Partners.Create
{
    internal class CreatePartnerCommandValidator : AbstractValidator<CreatePartnerCommand>
    {
        private readonly int _titleMaxLength;
        private readonly int _targetURLMaxLength;
        private readonly int _urlTitleMaxLength;
        private readonly int _descriptionMaxLength;

        public CreatePartnerCommandValidator()
        {
            _titleMaxLength = 255;
            _targetURLMaxLength = 255;
            _urlTitleMaxLength = 255;
            _descriptionMaxLength = 600;

            RuleFor(command => command.newPartner.Title)
                .NotEmpty()
                .WithMessage("Title is required.")
                .MaximumLength(_titleMaxLength)
                .WithMessage($"Title length must not be longer than {_titleMaxLength} symbols.");

            RuleFor(command => command.newPartner.LogoId)
                .NotEmpty()
                .WithMessage("LogoId is required.");

            RuleFor(command => command.newPartner.IsKeyPartner)
              .NotEmpty()
              .WithMessage("IsKeyPartner is required.");

            RuleFor(command => command.newPartner.IsVisibleEverywhere)
             .NotEmpty()
             .WithMessage("IsVisibleEverywhere is required.");

            RuleFor(command => command.newPartner.TargetUrl)
               .MaximumLength(_targetURLMaxLength)
               .WithMessage($"TargetUrl length must not be longer than {_targetURLMaxLength} symbols.");

            RuleFor(command => command.newPartner.UrlTitle)
               .MaximumLength(_urlTitleMaxLength)
               .WithMessage($"UrlTitle length must not be longer than {_urlTitleMaxLength} symbols.");

            RuleFor(command => command.newPartner.Description)
              .MaximumLength(_descriptionMaxLength)
              .WithMessage($"Description length must not be longer than {_descriptionMaxLength} symbols.");
        }
    }
}
