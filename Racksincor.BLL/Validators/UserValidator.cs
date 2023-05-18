using FluentValidation;
using Racksincor.BLL.DTO.User;

namespace Racksincor.BLL.Validators
{
    internal class UserValidator : AbstractValidator<UserDTO>
    {
        public UserValidator()
        {
            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("User email is required.")
                .MaximumLength(100).WithMessage("User email cannot exceed 100 characters.");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("User password is required.")
                .MaximumLength(100).WithMessage("User password exceed 100 characters.");
        }
    }
}
