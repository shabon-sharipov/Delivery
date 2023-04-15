using System.Net;
using System.Text.Json;

namespace Delivery.API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
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
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var errorResponse = new ErrorResponse()
            {
                Error = ex.Message,
                Status = (int)HttpStatusCode.InternalServerError,
                Title = ex switch
                {
                    BadHttpRequestException => "Bad request",
                    _ => "Internal Server Error."
                }
            };

            context.Response.StatusCode = errorResponse.Status;
            var result = JsonSerializer.Serialize(errorResponse);
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(result);
        }

        internal class ErrorResponse
        {
            public string Error { get; set; }
            public int Status { get; set; }
            public string Title { get; set; }
        }
    }
}
