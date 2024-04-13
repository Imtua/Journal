namespace Journal.Application.Validations.FluentValidation.Article
{
    public class UpdateArticleValidator : AbstractValidator<UpdateArticleDto>
    {
        public UpdateArticleValidator()
        {
            RuleFor(a => a.Title).NotEmpty().MaximumLength(100);
            RuleFor(a => a.Content).NotEmpty();
            RuleFor(a => a.Description).MaximumLength(300);
        }
    }
}
