using FluentValidation;

namespace Streetcode.BLL.MediatR.AdditionalContent.Coordinate.Create
{
    internal class CreateCoordinateCommandValidator : AbstractValidator<CreateCoordinateCommand>
    {
        public CreateCoordinateCommandValidator()
        {
            RuleFor(command => command.StreetcodeCoordinate.Latitude).NotEmpty().WithMessage("Latitude is required field.");
            RuleFor(command => command.StreetcodeCoordinate.Longtitude).NotEmpty().WithMessage("Longtitude is required field.");
        }
    }
}
