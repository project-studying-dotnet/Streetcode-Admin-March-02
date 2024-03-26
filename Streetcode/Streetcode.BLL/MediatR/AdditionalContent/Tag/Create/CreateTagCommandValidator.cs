using FluentValidation;

namespace Streetcode.BLL.MediatR.AdditionalContent.Tag.Create
{
    internal class CreateTagCommandValidator : AbstractValidator<CreateTagCommand>
    {
        public CreateTagCommandValidator()
        {
            RuleFor(command => command.tag.Title)
                .NotEmpty()
                .WithMessage("Title is required.")
                .MaximumLength(50)
                .WithMessage("Tag title length should not be longer then 50 symbols.");
        }
    }
}
