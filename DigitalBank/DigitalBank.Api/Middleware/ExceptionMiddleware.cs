using DigitalBank.Core.Custom_Exception;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace DigitalBank.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        public ExceptionMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _requestDelegate(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            context.Response.ContentType = "application/json";
            var problemDetails = new ProblemDetails
            {
                Title = exception.Message,
                Type = exception.GetType().Name,
                Instance = Guid.NewGuid().ToString()
            };
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Production")
            {
                problemDetails.Detail = exception.InnerException?.Message;
            }

            switch (exception)
            {                
                case UnauthorizedAccessException:
                    problemDetails.Status = (int)HttpStatusCode.Unauthorized;
                    break;

                default:
                    problemDetails.Status = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var result = JsonSerializer.Serialize(problemDetails);
            await response.WriteAsync(result);
        }
    }
}
