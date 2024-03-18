using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
// ReSharper disable UnusedType.Global
// ReSharper disable RedundantJumpStatement
// ReSharper disable ClassNeverInstantiated.Global

namespace ExceptionHandlingExamples.MvcFilters;

public class ValidationExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        context.Result = new OkResult();
        
        if (context.Exception is not ValidationException)
        {
            return;
        }
        
        // Handle ValidationException.
    }
}