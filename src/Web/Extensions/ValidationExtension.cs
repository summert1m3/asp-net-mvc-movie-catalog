﻿using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MovieCatalog.Web.Extensions;

public static class ValidationExtension
{
    public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState) 
    {
        if (!result.IsValid) 
        {
            foreach (var error in result.Errors) 
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}