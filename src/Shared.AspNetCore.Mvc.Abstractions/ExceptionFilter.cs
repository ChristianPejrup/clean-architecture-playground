using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Shared.Exceptions;

namespace Shared.AspNetCore.Mvc.Abstractions
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly IHostEnvironment _hostEnvironment;

        public ExceptionFilter(IHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public void OnException(ExceptionContext context)
        {
            var response = context.HttpContext.Response;
            response.StatusCode = GetStatusCode(context.Exception);
            response.ContentType = "application/text";
            var errorMessage = GetErrorMessage(context.Exception);
            response.WriteAsync(errorMessage);
            context.ExceptionHandled = true;
        }

        private int GetStatusCode(object exceptionType)
        {
            switch (exceptionType)
            {
                case NotFoundException _:
                    return StatusCodes.Status404NotFound;
                case UnauthorizedException _:
                    return StatusCodes.Status403Forbidden;
                case BaseException _:
                    return StatusCodes.Status400BadRequest;
                default:
                    return StatusCodes.Status500InternalServerError;
            }
        }

        private string GetErrorMessage(Exception exception)
        {
            if (exception.GetType().IsSubclassOf(typeof(BaseException)) || 
                _hostEnvironment.IsDevelopment())
            {
                return exception.Message;
            }
            return "Internal server error";
        }
    }
}