using FluentValidation;
using JobPortal.DTOs;

namespace JobPortal.Validators
{
    public class CreateJobDtoValidator : AbstractValidator<CreateJobDto>
    {
        public CreateJobDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Description)
                .NotEmpty();

            RuleFor(x => x.CompanyName)
                .NotEmpty();

            RuleFor(x => x.Location)
                .NotEmpty();

            RuleFor(x => x.Salary)
                .GreaterThan(0);
        }
    }
}