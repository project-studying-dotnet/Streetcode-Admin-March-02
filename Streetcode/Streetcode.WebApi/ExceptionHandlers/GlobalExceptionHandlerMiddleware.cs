using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Streetcode.WebApi.ExceptionHandlers
{
    public class GlobalExceptionHandlerMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

        public GlobalExceptionHandlerMiddleware(ILogger<GlobalExceptionHandlerMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (ValidationException ex)
            {
                var traceId = Guid.NewGuid();
                LogInfo(traceId, ex.Message, ex.StackTrace);

                context.Response.StatusCode = StatusCodes.Status400BadRequest;

                var problemDetails = new ProblemDetails
                {
                    Type = "ValidationFailure",
                    Title = "Validation error",
                    Status = StatusCodes.Status400BadRequest,
                    Instance = context.Request.Path,
                    Detail = $"One or more validation errors has occured, traceID: {traceId}",
                };

                if (ex.Errors is not null)
                {
                    problemDetails.Extensions["errors"] = ex.Errors;
                }

                await context.Response.WriteAsJsonAsync(problemDetails);
            }
            catch (Exception ex)
            {
                var traceId = Guid.NewGuid();
                LogInfo(traceId, ex.Message, ex.StackTrace);

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                var problemDetails = new ProblemDetails
                {
                    Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
                    Title = "Internal Server Error",
                    Status = StatusCodes.Status500InternalServerError,
                    Instance = context.Request.Path,
                    Detail = $"Internal server error occured, traceID: {traceId}",
                };

                await context.Response.WriteAsJsonAsync(problemDetails);
            }
        }

        private void LogInfo(Guid traceId, string message, string? stackTrace)
        {
            _logger.LogError($"Error occure while processing the request, TraceID: {traceId}, Message: {message}, StackTrace: {stackTrace}");
        }
    }
}
