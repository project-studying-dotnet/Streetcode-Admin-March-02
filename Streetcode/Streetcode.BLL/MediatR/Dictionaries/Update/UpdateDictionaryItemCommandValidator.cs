using FluentValidation;

namespace Streetcode.BLL.MediatR.Dictionaries.Update
{
    internal class UpdateDictionaryItemCommandValidator : AbstractValidator<UpdateDictionaryItemCommand>
    {
        public UpdateDictionaryItemCommandValidator()
        {
            RuleFor(command => command.dictionaryItem.Name)
                .MaximumLength(50)
                .WithMessage("Name length of dictionary item must not be longer than 50 symbols.");

            RuleFor(command => command.dictionaryItem.Description)
                    .MaximumLength(500)
                    .WithMessage("Description length of dictionary item must not be longer than 500 symbols.");
        }
    }
}
