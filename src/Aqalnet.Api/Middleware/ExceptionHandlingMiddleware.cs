using Aqalnet.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Aqalnet.Api.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<ExceptionHandlingMiddleware> logger
    )
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "exception occured: {Message}", ex.Message);

            var exceptionDetails = GetExceptionDetails(ex);

            var problemDetails = new ProblemDetails
            {
                Status = exceptionDetails.Status,
                Type = exceptionDetails.Type,
                Title = exceptionDetails.Title,
                Detail = ex.StackTrace
            };
        }
    }

    private static ExceptionDetails GetExceptionDetails(Exception ex)
    {
        return ex switch
        {
            ValidationException validationException
                => new ExceptionDetails(
                    StatusCodes.Status400BadRequest,
                    "ValidationFailure",
                    "Validation error ",
                    "One or more validation failures have occured",
                    validationException.Errors
                ),
            _
                => new ExceptionDetails(
                    StatusCodes.Status500InternalServerError,
                    "ServerError",
                    "Server error",
                    "An unexpected error occured",
                    null
                )
        };
    }

    internal record ExceptionDetails(
        int Status,
        string Type,
        string Title,
        string Detail,
        IEnumerable<object>? Errors
    );
}
