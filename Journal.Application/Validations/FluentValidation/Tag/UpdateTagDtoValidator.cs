namespace Journal.Application.Validations.FluentValidation.Tag
{
    public class UpdateTagDtoValidator : AbstractValidator<UpdateTagDto>
    {
        public UpdateTagDtoValidator()
        {
            RuleFor(t => t.Id).NotEmpty();
            RuleFor(t => t.Title).NotEmpty();
        }
    }
}
