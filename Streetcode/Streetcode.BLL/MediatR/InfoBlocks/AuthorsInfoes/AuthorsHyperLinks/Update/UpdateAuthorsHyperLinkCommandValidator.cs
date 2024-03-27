using FluentValidation;

namespace Streetcode.BLL.MediatR.InfoBlocks.AuthorsInfoes.AuthorsHyperLinks.Update
{
    internal class UpdateAuthorsHyperLinkCommandValidator : AbstractValidator<UpdateAuthorsHyperLinkCommand>
    {
        public UpdateAuthorsHyperLinkCommandValidator()
        {
            RuleFor(command => command.authorsHyperLink.Title)
                .MaximumLength(150)
                .WithMessage("Title length of author hyper link must not be longer than 150 symbols.");
        }
    }
}
