

using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TimeCop.Web.Extensions;


public static class Extensions
{
    public static void AddErrorsToModelState(this ValidationResult result, ModelStateDictionary modelState)
    {
        foreach (var error in result.Errors)
        {
            modelState.AddModelError("Input." + error.PropertyName, error.ErrorMessage);
        }
    }
}
