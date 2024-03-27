using FluentValidation;

namespace Streetcode.BLL.MediatR.InfoBlocks.Articles.Update
{
    internal class UpdateArticleCommandValidator : AbstractValidator<UpdateArticleCommand>
    {
        public UpdateArticleCommandValidator()
        {
            RuleFor(command => command.article.Title)
                .MaximumLength(50)
                .WithMessage("Title length of article must not be longer than 50 symbols.");

            RuleFor(command => command.article.Text)
                    .MaximumLength(15000)
                    .WithMessage("Text length of article must not be longer than 15000 symbols.");
        }
    }
}
