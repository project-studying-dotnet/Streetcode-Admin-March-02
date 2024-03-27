using FluentValidation;

namespace Streetcode.BLL.MediatR.InfoBlocks.AuthorsInfoes.AuthorsHyperLinks.Create
{
    public sealed class CreateAuthorsHyperLinkCommandValidator : AbstractValidator<CreateAuthorsHyperLinkCommand>
    {
        public CreateAuthorsHyperLinkCommandValidator()
        {
            RuleFor(command => command.newAuthorHyperLink.Title)
                .MaximumLength(150)
                .WithMessage("Title length of author hyper link must not be longer than 150 symbols.");
        }
    }
}
