using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using SDTur.Web.Models.Auth;
using SDTur.Web.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace SDTur.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IApiService _apiService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IApiService apiService, ILogger<AuthController> logger)
        {
            _apiService = apiService;
            _logger = logger;
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                return RedirectToAction("Dashboard", "Home");
            }
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Login attempt with invalid model state");
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    _logger.LogWarning("Model error: {ErrorMessage}", error.ErrorMessage);
                }
                return View(model);
            }

            try
            {
                _logger.LogInformation("Login attempt for user: {Username}", model.Username);

                var loginDto = new
                {
                    Username = model.Username,
                    Password = model.Password,
                };

                _logger.LogDebug("Calling API with login data");
                var response = await _apiService.PostAsync<object, LoginResponseViewModel>("api/auth/login", loginDto);
                _logger.LogDebug("API response received: {Response}", response?.ToString());

                if (response?.Success == true && response.UserInfo != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, response.UserInfo.Username),
                        new Claim(ClaimTypes.NameIdentifier, response.UserInfo.Id.ToString()),
                        new Claim(ClaimTypes.Role, response.UserInfo.Role ?? "User"),
                        new Claim("FirstName", response.UserInfo.FirstName ?? ""),
                        new Claim("LastName", response.UserInfo.LastName ?? ""),
                        new Claim("Email", response.UserInfo.Email ?? ""),
                        new Claim("IsActive", response.UserInfo.IsActive.ToString())
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = model.RememberMe,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddHours(8)
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    _logger.LogInformation("Login successful for user: {Username}", model.Username);
                    TempData["Success"] = "Giriş başarılı!";
                    return RedirectToAction("Dashboard", "Home");
                }
                else
                {
                    var errorMessage = response?.Message ?? "Giriş başarısız.";
                    _logger.LogWarning("Login failed for user {Username}: {ErrorMessage}", model.Username, errorMessage);
                    ModelState.AddModelError("", errorMessage);
                    return View(model);
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "HTTP request error during login for user: {Username}", model.Username);
                ModelState.AddModelError("", "API sunucusuna bağlanılamıyor. Lütfen daha sonra tekrar deneyin.");
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error during login for user: {Username}", model.Username);
                ModelState.AddModelError("", "Giriş sırasında bir hata oluştu. Lütfen daha sonra tekrar deneyin.");
                return View(model);
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                var username = User.Identity?.Name;
                _logger.LogInformation("Logout attempt for user: {Username}", username);

                // API'ye logout çağrısı yapılabilir
                try
                {
                    await _apiService.PostAsync<object, object>("api/auth/logout", new { });
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error during logout API call: {Message}", ex.Message);
                    // API hatası logout'u engellememeli
                }

                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                
                _logger.LogInformation("Logout successful for user: {Username}", username);
                TempData["Info"] = "Çıkış yapıldı.";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during logout");
                return RedirectToAction("Index", "Home");
            }
        }

        [Authorize]
        [HttpGet("profile")]
        public async Task<IActionResult> Profile()
        {
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
                if (userId <= 0)
                {
                    _logger.LogWarning("Invalid user ID in profile request");
                    return RedirectToAction("Login");
                }

                var user = await _apiService.GetAsync<UserProfileViewModel>($"api/users/{userId}");
                if (user == null)
                {
                    _logger.LogWarning("User not found for profile request: {UserId}", userId);
                    TempData["Error"] = "Kullanıcı bilgileri alınamadı.";
                    return RedirectToAction("Dashboard", "Home");
                }

                return View(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting user profile: {Message}", ex.Message);
                TempData["Error"] = "Profil bilgileri alınırken bir hata oluştu.";
                return RedirectToAction("Dashboard", "Home");
            }
        }

        [Authorize]
        [HttpGet("change-password")]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [Authorize]
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("ChangePassword called with invalid model state");
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    _logger.LogWarning("Model error: {ErrorMessage}", error.ErrorMessage);
                }
                return View(model);
            }

            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
                if (userId <= 0)
                {
                    _logger.LogWarning("Invalid user ID for password change");
                    TempData["Error"] = "Geçersiz kullanıcı.";
                    return View(model);
                }

                var changePasswordDto = new
                {
                    CurrentPassword = model.CurrentPassword,
                    NewPassword = model.NewPassword,
                    ConfirmPassword = model.ConfirmPassword
                };

                _logger.LogDebug("Calling API with change password data");
                var response = await _apiService.PostAsync<object, ChangePasswordResponseViewModel>("api/auth/change-password", changePasswordDto);
                _logger.LogDebug("API response received: {Response}", response?.ToString());

                if (response?.Success == true)
                {
                    _logger.LogInformation("Password change successful for user ID: {UserId}", userId);
                    TempData["Success"] = "Şifre başarıyla değiştirildi.";
                    return RedirectToAction("Profile");
                }
                else
                {
                    var errorMessage = response?.Message ?? "Şifre değiştirme başarısız.";
                    _logger.LogWarning("Password change failed: {ErrorMessage}", errorMessage);
                    ModelState.AddModelError("", errorMessage);
                    return View(model);
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "HTTP request error during password change");
                ModelState.AddModelError("", "API sunucusuna bağlanılamıyor. Lütfen daha sonra tekrar deneyin.");
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during password change: {Message}", ex.Message);
                ModelState.AddModelError("", "Şifre değiştirme sırasında bir hata oluştu.");
                return View(model);
            }
        }
    }
} 