using Castle.Core.Logging;
using D2Store.Business.Exceptions;
using D2Store.Common.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security;
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
            catch (Exception ex)
            {
                httpContext.Response.StatusCode = ex switch
                {
                    ValidationException => (int)HttpStatusCode.BadRequest,
                    SecurityTokenValidationException => (int)HttpStatusCode.BadRequest,
                    ArgumentNullException => (int)HttpStatusCode.NotFound,
                    VerificationException => (int)HttpStatusCode.NotFound,
                    ForbiddenException => (int)HttpStatusCode.Forbidden,
                    _ => (int)HttpStatusCode.InternalServerError
                };

                await CreateExceptionResponseAsync(httpContext, ex.Message);
            }
        }

        private async Task CreateExceptionResponseAsync(HttpContext context, string message)
        {
            _logger.LogError(message);

            context.Response.ContentType = "application/json";

            var error = new ErrorDTO()
            {
                Message = message,
                StatusCode = context.Response.StatusCode
            };

            string result = JsonSerializer.Serialize(error);

            await context.Response.WriteAsync(result);
        }
    }
}
