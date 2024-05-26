using Castle.Core.Logging;
using D2Store.Business.Exceptions;
using D2Store.Common.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace D2Store.Business.ExceptionHandler
{
    public class ExceptionHandlerMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleWare> _logger;

        public ExceptionHandlerMiddleWare(RequestDelegate next,
            ILogger<ExceptionHandlerMiddleWare> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (ClientNotFoundException ex)
            {
                await HandleExceptionAsync(httpContext,
                    ex.Message,
                    HttpStatusCode.NotFound,
                    "asdasdasd");
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext,
            string exceptionMessage,
            HttpStatusCode httpStatusCode,
            string message)
        {
            _logger.LogError(exceptionMessage);

            HttpResponse response = httpContext.Response;

            response.ContentType = "application/json";
            response.StatusCode = (int)httpStatusCode;

            ErrorDTO errorDTO = new()
            {
                Message = message,
                StatusCode = (int)httpStatusCode
            };

            string result = JsonSerializer.Serialize(errorDTO);

            await response.WriteAsJsonAsync(result);
        }
    }
}
