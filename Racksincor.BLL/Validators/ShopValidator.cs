using FluentValidation;
using Racksincor.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racksincor.BLL.Validators
{
    public class ShopValidator : AbstractValidator<ShopDTO>
    {
        public ShopValidator()
        {
            RuleFor(shop => shop.Name)
                .NotEmpty().WithMessage("Shop name is required.")
                .MaximumLength(100).WithMessage("Shop name cannot exceed 100 characters.");

            RuleFor(shop => shop.Address)
                .NotEmpty().WithMessage("Shop address is required.")
                .MaximumLength(200).WithMessage("Shop address cannot exceed 200 characters.");

            RuleFor(shop => shop.CompanyId)
                .NotEmpty().WithMessage("Company id is required");
        }
    }
}
