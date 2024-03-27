using FluentValidation;

namespace Streetcode.BLL.MediatR.InfoBlocks.Articles.Create
{
    public sealed class CreateArticleCommandValidator : AbstractValidator<CreateArticleCommand>
    {
        public CreateArticleCommandValidator()
        {
            RuleFor(command => command.newArticle.Title)
                .MaximumLength(50)
                .WithMessage("Title length of article must not be longer than 50 symbols.");

            RuleFor(command => command.newArticle.Text)
                .MaximumLength(15000)
                .WithMessage("Text length of article must not be longer than 15000 symbols.");
        }
    }
}
