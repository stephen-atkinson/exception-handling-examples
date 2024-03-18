using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
// ReSharper disable UnusedType.Global
// ReSharper disable ConvertToPrimaryConstructor

namespace ExceptionHandling.MiddlewareExceptionHandler;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly IProblemDetailsService _problemDetailsService;

    public GlobalExceptionHandler(IProblemDetailsService problemDetailsService)
    {
        _problemDetailsService = problemDetailsService;
    }
    
    public ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var context = new ProblemDetailsContext
        {
            HttpContext = httpContext,
            Exception = exception,
            ProblemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError
                // Defaults will be used for missing members by IProblemDetailsService.
            }
        };
        
        return _problemDetailsService.TryWriteAsync(context);
    }
}