using FluentValidation;
using Racksincor.BLL.DTO;

namespace Racksincor.BLL.Validators
{
    public class CompanyValidator : AbstractValidator<CompanyDTO>
    {
        public CompanyValidator()
        {
            RuleFor(company => company.Name)
                .NotEmpty().WithMessage("Company name is required.")
                .MaximumLength(100).WithMessage("Company name cannot exceed 100 characters.");

            RuleFor(company => company.Url)
                .NotEmpty().WithMessage("Company URL is required.")
                .MaximumLength(100).WithMessage("Company URL cannot exceed 100 characters.");
        }
    }
}
