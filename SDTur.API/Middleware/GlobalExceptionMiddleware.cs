using System.Net;
using System.Text.Json;

namespace SDTur.API.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;
        private readonly IWebHostEnvironment _environment;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger, IWebHostEnvironment environment)
        {
            _next = next;
            _logger = logger;
            _environment = environment;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred: {Message}", ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            
            var response = new
            {
                success = false,
                message = "Bir hata oluştu. Lütfen daha sonra tekrar deneyin.",
                error = new
                {
                    type = exception.GetType().Name,
                    message = _environment.IsDevelopment() ? exception.Message : "Internal server error",
                    details = _environment.IsDevelopment() ? exception.StackTrace : null
                },
                timestamp = DateTime.UtcNow
            };

            switch (exception)
            {
                case UnauthorizedAccessException:
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    response = new
                    {
                        success = false,
                        message = "Bu işlem için yetkiniz bulunmamaktadır.",
                        error = new
                        {
                            type = "Unauthorized",
                            message = exception.Message,
                            details = _environment.IsDevelopment() ? exception.StackTrace : null
                        },
                        timestamp = DateTime.UtcNow
                    };
                    break;
                    
                case ArgumentException:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response = new
                    {
                        success = false,
                        message = "Geçersiz parametreler gönderildi.",
                        error = new
                        {
                            type = "InvalidArgument",
                            message = exception.Message,
                            details = _environment.IsDevelopment() ? exception.StackTrace : null
                        },
                        timestamp = DateTime.UtcNow
                    };
                    break;
                    
                case InvalidOperationException:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response = new
                    {
                        success = false,
                        message = "İşlem gerçekleştirilemedi.",
                        error = new
                        {
                            type = "InvalidOperation",
                            message = exception.Message,
                            details = _environment.IsDevelopment() ? exception.StackTrace : null
                        },
                        timestamp = DateTime.UtcNow
                    };
                    break;
                    
                case KeyNotFoundException:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    response = new
                    {
                        success = false,
                        message = "İstenen kayıt bulunamadı.",
                        error = new
                        {
                            type = "NotFound",
                            message = exception.Message,
                            details = _environment.IsDevelopment() ? exception.StackTrace : null
                        },
                        timestamp = DateTime.UtcNow
                    };
                    break;
                    
                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var jsonResponse = JsonSerializer.Serialize(response, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            await context.Response.WriteAsync(jsonResponse);
        }
    }

    public static class GlobalExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalExceptionMiddleware>();
        }
    }
} 