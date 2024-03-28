using FluentValidation;
using Streetcode.BLL.MediatR.Sources.SourceLinkCategory;

namespace Streetcode.BLL.MediatR.Sources.StreetcodeCategoryContent.Create
{
    public sealed class CreateStreetcodeCategoryContentCommandValidator : AbstractValidator<CreateStreetcodeCategoryContentCommand>
    {
        public CreateStreetcodeCategoryContentCommandValidator()
        {
            RuleFor(command => command.StreetcodeCategoryContentDto.Text)
                .MaximumLength(4000)
                .WithMessage("Text length must not be longer than 4000 symbols.");
        }
    }
}
