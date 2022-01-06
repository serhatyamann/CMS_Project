using CMS.Application.Models.DTOs;
using FluentValidation;

namespace CMS.Application.Validation.FluentValidation
{
    public class RegisterValidation : AbstractValidator<RegisterDTO>
    {
        public RegisterValidation()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Enter an email address")
                .EmailAddress()
                .WithMessage("Enter a valid a email address");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Enter a password");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password)
                .WithMessage("Passwords don't match");

            RuleFor(x => x.FullName)
                .NotEmpty()
                .WithMessage("Name can't be empty")
                .MinimumLength(3)
                .MaximumLength(50)
                .WithMessage("Min 3, max 50 character");
        }
    }
}
