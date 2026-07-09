using FluentValidation;
using JobPortal.DTOs;

namespace JobPortal.Validators
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6);

            RuleFor(x => x.Role)
                .Must(role => role == "Recruiter" || role == "JobSeeker")
                .WithMessage("Role must be either Recruiter or JobSeeker.");
        }
    }
}