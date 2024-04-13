namespace Journal.Application.Validations.FluentValidation.Comment
{
    public class CreateCommentValidator : AbstractValidator<CreateCommentDto>
    {
        public CreateCommentValidator()
        {
            RuleFor(c => c.Text).NotEmpty().MinimumLength(1000);
            RuleFor(c => c.ArticleId).NotEmpty();
            RuleFor(c => c.UserId).NotEmpty();
        }
    }
}
