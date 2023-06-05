using FluentValidation;
using Racksincor.BLL.DTO.User;

namespace Racksincor.BLL.Validators
{
    public class UserUpdateValidator : AbstractValidator<UserUpdateDTO>
    {
        public UserUpdateValidator()
        {
            RuleFor(register => register.Email)
                .NotEmpty().WithMessage("Email is required.")
                .MaximumLength(100).WithMessage("Email cannot exceed 100 characters.");

            RuleFor(register => register.Password)
                .MaximumLength(100)
                    .When(register => string.IsNullOrEmpty(register.Password) == false)
                    .WithMessage("Password exceed 100 characters.")
                .Equal(register => register.PasswordConfirm)
                    .When(register => string.IsNullOrEmpty(register.Password) == false)
                    .WithMessage("Passwords don't match.");
        }
    }
}
