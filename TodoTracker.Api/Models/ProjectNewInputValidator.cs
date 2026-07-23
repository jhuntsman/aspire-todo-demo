using FluentValidation;

namespace TodoTracker.Api.Types;

public class ProjectNewInputValidator : AbstractValidator<ProjectNewInput>
{
    public ProjectNewInputValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(250).WithMessage("Name must be less than 250 characters");
    }
}