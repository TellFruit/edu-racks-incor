using FluentValidation;
using Racksincor.BLL.DTO.User;

namespace Racksincor.BLL.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterDTO>
    {
        public RegisterValidator()
        {
            RuleFor(register => register.Email)
                .NotEmpty().WithMessage("Email is required.")
                .MaximumLength(100).WithMessage("Email cannot exceed 100 characters.");

            RuleFor(register => register.Password)
                .MaximumLength(100).WithMessage("Password exceed 100 characters.")
                .NotEmpty().WithMessage("Password is required.")
                .Equal(register => register.PasswordConfirm).WithMessage("Passwords don't match.");

            RuleFor(register => register.PasswordConfirm)
                .NotEmpty().WithMessage("Password confirmation is required.");
        }
    }
}
