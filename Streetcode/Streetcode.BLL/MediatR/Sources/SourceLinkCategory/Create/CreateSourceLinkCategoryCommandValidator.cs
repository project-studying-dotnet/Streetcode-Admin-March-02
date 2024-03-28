using FluentValidation;
using Streetcode.BLL.MediatR.Timeline.HistoricalContext.Create;

namespace Streetcode.BLL.MediatR.Sources.SourceLinkCategory.Create
{
    public sealed class CreateSourceLinkCategoryCommandValidator : AbstractValidator<CreateSourceLinkCategoryCommand>
    {
        public CreateSourceLinkCategoryCommandValidator()
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
