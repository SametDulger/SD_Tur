using SDTur.Web.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// HttpContext Accessor
builder.Services.AddHttpContextAccessor();

// Session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(8);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
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
    });

// Authorization
builder.Services.AddAuthorization(options =>
{
    options.DefaultPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});

// HTTP Client for API communication
builder.Services.AddHttpClient<IApiService, ApiService>(client =>
{
    // API URL'ini yapılandırmadan al, varsayılan olarak localhost:7001 kullan
    var apiUrl = builder.Configuration["ApiSettings:BaseUrl"] ?? "https://localhost:7001/";
    Console.WriteLine($"Configuring API client with URL: {apiUrl}");
    client.BaseAddress = new Uri(apiUrl);
    client.Timeout = TimeSpan.FromSeconds(30);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

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

Console.WriteLine("Web application starting...");
Console.WriteLine($"API Base URL: {builder.Configuration["ApiSettings:BaseUrl"] ?? "https://localhost:7001/"}");

app.Run();
