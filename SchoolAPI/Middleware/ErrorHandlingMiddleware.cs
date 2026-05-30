using System.Net;
using System.Text.Json;

namespace SchoolAPI.Middileware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next , ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger= logger;
            _next= next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);


            }
            catch (Exception ex) {

                _logger.LogError(ex, "Unhandled exception occurred");
                await HandleExceptionAsync (context, ex);
            }

        }
        private static Task HandleExceptionAsync(HttpContext context, Exception ex) {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode= (int)HttpStatusCode.InternalServerError;
            var response = new
            {
                StatusCode = 500,
                Message = "unexpected error accurred",
                Detail = ex.Message
            };
            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

    }
}