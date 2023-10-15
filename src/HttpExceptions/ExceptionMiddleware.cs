using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HttpExceptions
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly IHostEnvironment _hostEnvironment;

        public ExceptionMiddleware(IHostEnvironment hostEnvironment) =>
            _hostEnvironment = hostEnvironment;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                var errorResponse = new ErrorResponse()
                {
                    Exception = exception.Message.Trim(),
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };

                if (_hostEnvironment.IsDevelopment())
                {
                    errorResponse.StackTrace = exception.StackTrace;
                    errorResponse.Source = exception.TargetSite?.DeclaringType?.FullName;
                }

                if (exception is HttpException httpException)
                {
                    errorResponse.StatusCode = (int)httpException.StatusCode;
                    if (httpException.ErrorMessages is not null)
                        errorResponse.Messages = httpException.ErrorMessages;
                }

                if (exception.InnerException != null)
                {
                    errorResponse.Messages = GetInnerExceptions(exception);
                }

                await SetResponseAsync(context, errorResponse);
            }
        }

        private static List<string> GetInnerExceptions(Exception exception)
        {
            var innerExceptions = new List<string>();
            while (exception != null)
            {
                innerExceptions.Add(exception.Message);
                exception = exception.InnerException!;
            }
            return innerExceptions;
        }

        private static async Task SetResponseAsync(HttpContext context, ErrorResponse errorResponse)
        {
            context.Response.StatusCode = errorResponse.StatusCode;
            context.Response.ContentType = "application/json";
            var jsonResponse = JsonSerializer.Serialize(errorResponse, new JsonSerializerOptions()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            });
            await context.Response.WriteAsync(jsonResponse);
        }
    }
}
