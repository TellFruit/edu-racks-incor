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

            RuleFor(company => company.Address)
                .NotEmpty().WithMessage("Company address is required.")
                .MaximumLength(200).WithMessage("Company address cannot exceed 200 characters.");
        }
    }
}
