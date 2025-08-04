using SDTur.Web.Services;
using SDTur.Web.Middleware;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Http;
using Polly;
using Polly.Extensions.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// HttpContext Accessor
builder.Services.AddHttpContextAccessor();

// Session configuration
var sessionSettings = builder.Configuration.GetSection("SessionSettings");
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(sessionSettings.GetValue<int>("IdleTimeout", 480));
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.Name = sessionSettings.GetValue<string>("CookieName", "SDTur.Session");
});

// Authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Login";
        options.LogoutPath = "/Auth/Logout";
        options.AccessDeniedPath = "/Auth/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromHours(8);
        options.SlidingExpiration = true;
        options.Cookie.Name = "SDTur.Auth";
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
        options.Events.OnRedirectToLogin = context =>
        {
            context.Response.StatusCode = 401;
            return Task.CompletedTask;
        };
    });

// Authorization
builder.Services.AddAuthorization(options =>
{
    options.DefaultPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});

// HTTP Client for API communication with retry policy
var apiSettings = builder.Configuration.GetSection("ApiSettings");
builder.Services.AddHttpClient<IApiService, ApiService>(client =>
{
    var apiUrl = apiSettings["BaseUrl"] ?? "https://localhost:7001/";
    client.BaseAddress = new Uri(apiUrl);
    client.Timeout = TimeSpan.FromSeconds(apiSettings.GetValue<int>("Timeout", 30));
    client.DefaultRequestHeaders.Add("User-Agent", "SDTur-Web-Client");
})
.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
{
    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
})
.AddPolicyHandler(GetRetryPolicy(apiSettings));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Add security headers middleware
app.UseSecurityHeaders();

// Add error handling middleware
app.UseErrorHandling();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Configure custom port for the web application
app.Urls.Clear();
app.Urls.Add("http://localhost:5018");
app.Urls.Add("https://localhost:7276");

var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Web application starting...");
logger.LogInformation("API Base URL: {ApiBaseUrl}", apiSettings["BaseUrl"] ?? "https://localhost:7001/");

app.Run();

// Retry policy configuration
static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy(IConfigurationSection apiSettings)
{
    return HttpPolicyExtensions
        .HandleTransientHttpError()
        .WaitAndRetryAsync(
            retryCount: apiSettings.GetValue<int>("RetryCount", 3),
            sleepDurationProvider: retryAttempt => 
                TimeSpan.FromMilliseconds(apiSettings.GetValue<int>("RetryDelay", 1000) * retryAttempt),
            onRetry: (outcome, timespan, retryAttempt, context) =>
            {
                // Log retry attempt (logger not available in this context)
                System.Diagnostics.Debug.WriteLine($"API request failed. Retry attempt {retryAttempt} after {timespan.TotalSeconds} seconds.");
            });
}
