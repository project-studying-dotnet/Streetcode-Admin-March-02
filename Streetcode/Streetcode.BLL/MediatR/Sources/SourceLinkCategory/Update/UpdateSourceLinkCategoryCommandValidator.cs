using FluentValidation;

namespace Streetcode.BLL.MediatR.Sources.SourceLinkCategory.Update
{
    public sealed class UpdateSourceLinkCategoryCommandValidator : AbstractValidator<UpdateSourceLinkCategoryCommand>
    {
        public UpdateSourceLinkCategoryCommandValidator()
        {
            RuleFor(command => command.sourceLinkCategoryDto.Title)
                .NotEmpty()
                .WithMessage("Title is mandatory.")
                .MaximumLength(100)
                .WithMessage("Title length of category must not be longer than 100 symbols.");

            RuleFor(command => command.sourceLinkCategoryDto.Image)
                .NotNull()
                .WithMessage("Title is mandatory.");
        }
    }
}
