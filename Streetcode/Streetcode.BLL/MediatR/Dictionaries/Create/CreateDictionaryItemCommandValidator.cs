using FluentValidation;

namespace Streetcode.BLL.MediatR.Dictionaries.Create
{
    public sealed class CreateDictionaryItemCommandValidator : AbstractValidator<CreateDictionaryItemCommand>
    {
        public CreateDictionaryItemCommandValidator()
        {
            RuleFor(command => command.newDictionaryItem.Name)
                .MaximumLength(50)
                .WithMessage("Name length of dictionary item must not be longer than 50 symbols.");

            RuleFor(command => command.newDictionaryItem.Description)
                .MaximumLength(500)
                .WithMessage("Description length of dictionary item must not be longer than 500 symbols.");
        }
    }
}
