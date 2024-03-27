using FluentValidation;

namespace Streetcode.BLL.MediatR.Partners.Update
{
    internal class UpdatePartnerCommandValidator : AbstractValidator<UpdatePartnerQuery>
    {
        private readonly int _titleMaxLength;
        private readonly int _targetURLMaxLength;
        private readonly int _urlTitleMaxLength;
        private readonly int _descriptionMaxLength;

        public UpdatePartnerCommandValidator()
        {
            _titleMaxLength = 255;
            _targetURLMaxLength = 255;
            _urlTitleMaxLength = 255;
            _descriptionMaxLength = 600;

            RuleFor(command => command.Partner.Title)
                .NotEmpty()
                .WithMessage("Title is required.")
                .MaximumLength(_titleMaxLength)
                .WithMessage($"Title length must not be longer than {_titleMaxLength} symbols.");

            RuleFor(command => command.Partner.LogoId)
                .NotEmpty()
                .WithMessage("LogoId is required.");

            RuleFor(command => command.Partner.IsKeyPartner)
              .NotEmpty()
              .WithMessage("IsKeyPartner is required.");

            RuleFor(command => command.Partner.IsVisibleEverywhere)
             .NotEmpty()
             .WithMessage("IsVisibleEverywhere is required.");

            RuleFor(command => command.Partner.TargetUrl)
               .MaximumLength(_targetURLMaxLength)
               .WithMessage($"TargetUrl length must not be longer than {_targetURLMaxLength} symbols.");

            RuleFor(command => command.Partner.UrlTitle)
               .MaximumLength(_urlTitleMaxLength)
               .WithMessage($"UrlTitle length must not be longer than {_urlTitleMaxLength} symbols.");

            RuleFor(command => command.Partner.Description)
              .MaximumLength(_descriptionMaxLength)
              .WithMessage($"Description length must not be longer than {_descriptionMaxLength} symbols.");
        }
    }
}
