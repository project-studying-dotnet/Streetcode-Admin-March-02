using System;
using FluentValidation;
using Streetcode.BLL.MediatR.Partners.Create;
using Streetcode.BLL.MediatR.Team.Create;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Streetcode.BLL.MediatR.Team.Position.Create
{
    internal class CreatePositionCommandValidator : AbstractValidator<CreatePositionQuery>
    {
        private readonly int _positionMaxLength;

        public CreatePositionCommandValidator()
        {
            _positionMaxLength = 50;

            RuleFor(command => command.position.Position)
                .NotEmpty()
                .WithMessage("Position is required.")
                .MaximumLength(_positionMaxLength)
                .WithMessage($"Position length must not be longer than {_positionMaxLength} symbols.");
        }
    }
}
