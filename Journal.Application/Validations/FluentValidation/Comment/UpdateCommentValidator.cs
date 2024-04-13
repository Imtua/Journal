namespace Journal.Application.Validations.FluentValidation.Comment
{
    public class UpdateCommentValidator : AbstractValidator<UpdateCommentDto>
    {
        public UpdateCommentValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.Text).NotEmpty().MinimumLength(1000);
            RuleFor(c => c.ArticleId).NotEmpty();
            RuleFor(c => c.UserId).NotEmpty();
        }
    }
}
