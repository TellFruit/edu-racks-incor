using FluentValidation;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Racksincor
{
    internal static class ValidationExtension
    {
        public static void AddToModelState(this ValidationException ex, ModelStateDictionary modelState)
        {
            foreach (var error in ex.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}
