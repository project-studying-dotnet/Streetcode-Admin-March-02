using FluentValidation;

namespace Streetcode.BLL.MediatR.AdditionalContent.Coordinate.Update
{
    internal class UpdateCoordinateCommandValidator : AbstractValidator<UpdateCoordinateCommand>
    {
        public UpdateCoordinateCommandValidator()
        {
            RuleFor(command => command.StreetcodeCoordinate.Latitude).NotEmpty().WithMessage("Latitude is required field.");
            RuleFor(command => command.StreetcodeCoordinate.Longtitude).NotEmpty().WithMessage("Longtitude is required field.");
        }
    }
}
