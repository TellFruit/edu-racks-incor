using FluentValidation;
using Racksincor.BLL.DTO.User;

namespace Racksincor.BLL.Validators
{
    public class UserUpdateValidator : AbstractValidator<RegisterDTO>
    {
        public UserUpdateValidator()
        {
            RuleFor(register => register.Email)
                .NotEmpty().WithMessage("Email is required.")
                .MaximumLength(100).WithMessage("Email cannot exceed 100 characters.");
        }
    }
}
