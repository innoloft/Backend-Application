using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace BackendApplication
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ExceptionFilter> logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            this.logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            if (context.Exception is RequestException)
            {
                context.HttpContext.Response.StatusCode = (context.Exception as RequestException).Code;
                context.Result = new ObjectResult(string.Empty);
            }
            else
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                logger.LogError(context.Exception.Message);
                logger.LogError(context.Exception.StackTrace);
                context.Result = new ObjectResult(string.Empty);
            }
        }
    }
}
