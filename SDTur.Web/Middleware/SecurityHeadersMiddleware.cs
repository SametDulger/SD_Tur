namespace SDTur.Web.Middleware
{
    public class SecurityHeadersMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<SecurityHeadersMiddleware> _logger;

        public SecurityHeadersMiddleware(RequestDelegate next, ILogger<SecurityHeadersMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Security Headers
                context.Response.Headers["X-Content-Type-Options"] = "nosniff";
                context.Response.Headers["X-Frame-Options"] = "DENY";
                context.Response.Headers["X-XSS-Protection"] = "1; mode=block";
                context.Response.Headers["Referrer-Policy"] = "strict-origin-when-cross-origin";
                context.Response.Headers["Permissions-Policy"] = "geolocation=(), microphone=(), camera=()";

                // Content Security Policy
                var csp = "default-src 'self'; " +
                         "script-src 'self' 'unsafe-inline' 'unsafe-eval' https://cdn.jsdelivr.net; " +
                         "style-src 'self' 'unsafe-inline' https://cdn.jsdelivr.net; " +
                         "font-src 'self' https://cdn.jsdelivr.net; " +
                         "img-src 'self' data: https:; " +
                         "connect-src 'self' https://localhost:7001; " +
                         "frame-ancestors 'none';";

                context.Response.Headers["Content-Security-Policy"] = csp;

                // Strict Transport Security (HSTS)
                if (context.Request.IsHttps)
                {
                    context.Response.Headers["Strict-Transport-Security"] = "max-age=31536000; includeSubDomains";
                }

                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in SecurityHeadersMiddleware");
                await _next(context);
            }
        }
    }

    public static class SecurityHeadersMiddlewareExtensions
    {
        public static IApplicationBuilder UseSecurityHeaders(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SecurityHeadersMiddleware>();
        }
    }
} 