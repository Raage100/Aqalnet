using Aqalnet.Application.Abstractions.Messaging;
using Aqalnet.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Aqalnet.Application.Abstractions.Behaviors;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IBaseRequest
    where TResponse : Result
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken
    )
    {
        var name = request.GetType().Name;

        try
        {
            _logger.LogInformation("Executing request {Request}", name);
            var result = await next();
            if (result.IsSuccess)
            {
                _logger.LogInformation("Request {Request} processed successfully", name);
            }
            else
            {
                
                
                    _logger.LogError("Request {Request} processing with error", name);
                
            }

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Request {Request} processing failed", name);
            throw;
        }
    }
}
