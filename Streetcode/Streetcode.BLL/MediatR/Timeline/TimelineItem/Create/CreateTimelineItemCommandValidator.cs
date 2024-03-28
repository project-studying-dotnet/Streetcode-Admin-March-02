using System;
using FluentValidation;
using Streetcode.BLL.MediatR.Team.Create;

namespace Streetcode.BLL.MediatR.Timeline.TimelineItem.Create
{
    internal class CreateTimelineItemCommandValidator : AbstractValidator<CreateTimelineItemCommand>
    {
        private readonly int _titleMaxLength;
        private readonly int _descriptionMaxLength;

        public CreateTimelineItemCommandValidator()
        {
            _titleMaxLength = 100;
            _descriptionMaxLength = 600;

            RuleFor(command => command.TimelineItem.Date)
                .NotEmpty()
                .WithMessage("Date is required.");

            RuleFor(command => command.TimelineItem.DateViewPattern)
                .NotEmpty()
                .WithMessage("DataViewPattern is required.");

            RuleFor(command => command.TimelineItem.Title)
                .NotEmpty()
                .WithMessage("Title is required.")
                .MaximumLength(_titleMaxLength)
                .WithMessage($"Title length must not be longer than {_titleMaxLength} symbols.");

            RuleFor(command => command.TimelineItem.Description)
                .MaximumLength(_descriptionMaxLength)
                .WithMessage($"Title length must not be longer than {_descriptionMaxLength} symbols.");
        }
    }
}