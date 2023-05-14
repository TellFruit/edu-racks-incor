using FluentValidation;
using Racksincor.BLL.DTO;
using Racksincor.BLL.DTO.Abstract;

namespace Racksincor.BLL
{
    internal static class ValidationExtension
    {
        private static async Task ValidateAndThrow<TEntity>(this AbstractValidator<TEntity> validator, TEntity entry)
            where TEntity : BaseDTO
        {
            var validationResult = await validator.ValidateAsync(entry);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
        }
    }
}
