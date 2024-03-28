using System;
using FluentValidation;
using Streetcode.BLL.MediatR.Team.Create;

namespace Streetcode.BLL.MediatR.Team.TeamMembersLinks.Create
{
    internal class CreateTeamLinkCommandValidator : AbstractValidator<CreateTeamLinkQuery>
    {
        private readonly int _targetUrlMaxLength;

        public CreateTeamLinkCommandValidator()
        {
            _targetUrlMaxLength = 255;

            RuleFor(command => command.teamMember.LogoType)
                .NotEmpty()
                .WithMessage("LogoType is required.");

            RuleFor(command => command.teamMember.TargetUrl)
                .NotEmpty()
                .WithMessage("TargetUrl is required.")
                .MaximumLength(_targetUrlMaxLength)
                .WithMessage($"TargetUrl length must not be longer than {_targetUrlMaxLength} symbols.");

            RuleFor(command => command.teamMember.TeamMemberId)
                .NotEmpty()
                .WithMessage("TeamMemberId is required.");
        }
    }
}
