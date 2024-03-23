using FluentValidation;

namespace Streetcode.BLL.MediatR.Timeline.HistoricalContext.Create
{
    public sealed class CreateHistoricalContextCommandValidator : AbstractValidator<CreateHistoricalContextCommand>
    {
        public CreateHistoricalContextCommandValidator()
        {
            RuleFor(command => command.NewHistoricalContext.Title)
                .MaximumLength(50)
                .WithMessage("Title length of historical context must not be longer than 50 symbols.");
        }
    }
}
