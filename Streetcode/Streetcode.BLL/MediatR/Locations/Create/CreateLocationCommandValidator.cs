using FluentValidation;

namespace Streetcode.BLL.MediatR.Locations.Create
{
    public sealed class CreateLocationCommandValidator : AbstractValidator<CreateLocationCommand>
    {
        public CreateLocationCommandValidator()
        {
            RuleFor(command => command.newLocation.Streetname)
                .NotEmpty()
                .MaximumLength(128)
                .WithMessage("Streetname length of location must not be longer than 128 symbols.");

            RuleFor(command => command.newLocation.TableNumber)
                .NotEmpty();
        }
    }
}
