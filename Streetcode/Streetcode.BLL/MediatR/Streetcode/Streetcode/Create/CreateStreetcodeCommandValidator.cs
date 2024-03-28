using FluentValidation;

namespace Streetcode.BLL.MediatR.Streetcode.Streetcode.Create
{
    internal class CreateStreetcodeCommandValidator : AbstractValidator<CreateStreetcodeCommand>
    {
        private readonly ushort _maxTitleLength;
        private readonly ushort _maxTeaserLength;
        private readonly ushort _maxSmallDescriptionLength;
        private readonly ushort _maxURLLength;
        private readonly ushort _maxNameLength;
        private readonly ushort _maxSurnameLength;

        public CreateStreetcodeCommandValidator()
        {
            _maxTitleLength = 100;
            _maxTeaserLength = 450;
            _maxSmallDescriptionLength = 33;
            _maxURLLength = 100;
            _maxNameLength = 50;
            _maxSurnameLength = 50;

            RuleFor(command => command.StreetcodeDto.Index).NotEmpty()
                                                           .WithMessage("Index is required.");

            RuleFor(command => command.StreetcodeDto.Title).MaximumLength(_maxTitleLength)
                .WithMessage($"Title length must not be longer than {_maxTitleLength} symbols.");

            RuleFor(command => command.StreetcodeDto.Teaser).MaximumLength(_maxTeaserLength)
                .WithMessage($"Teaser length must not be longer than {_maxTeaserLength} symbols.");

            RuleFor(command => command.StreetcodeDto.SmallDescription).MaximumLength(_maxSmallDescriptionLength)
               .WithMessage($"Small description length must not be longer than {_maxSmallDescriptionLength} symbols.");

            RuleFor(command => command.StreetcodeDto.URL).MaximumLength(_maxURLLength)
               .WithMessage($"URL length must not be longer than {_maxURLLength} symbols.");

            RuleFor(command => command.StreetcodeDto.Name).MaximumLength(_maxNameLength)
              .WithMessage($"Name length must not be longer than {_maxNameLength} symbols.");

            RuleFor(command => command.StreetcodeDto.Surname).MaximumLength(_maxSurnameLength)
             .WithMessage($"Surname length must not be longer than {_maxSurnameLength} symbols.");
        }
    }
}
