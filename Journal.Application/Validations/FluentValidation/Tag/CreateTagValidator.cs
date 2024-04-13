namespace Journal.Application.Validations.FluentValidation.Tag
{
    public class CreateTagValidator : AbstractValidator<CreateTagDto>
    {
        public CreateTagValidator()
        {
            RuleFor(t => t.Title).NotEmpty();
        }
    }
}
