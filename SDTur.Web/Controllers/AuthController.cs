using Microsoft.AspNetCore.Mvc;
using SDTur.Web.Models.Auth;
using SDTur.Web.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace SDTur.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IApiService _apiService;

        public AuthController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet("login")]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl ?? "";
            return View();
        }

        [HttpPost("login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl ?? "";

            // Model validation
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Login attempt with invalid model state");
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Model error: {error.ErrorMessage}");
                }
                return View(model);
            }

            try
            {
                Console.WriteLine($"Login attempt for user: {model.Username}");
                
                var loginDto = new
                {
                    Username = model.Username,
                    Password = model.Password,
                    RememberMe = model.RememberMe
                };

                Console.WriteLine("Calling API with login data");
                
                var response = await _apiService.PostAsync<object, LoginResponseViewModel>("api/auth/login", loginDto);
                
                Console.WriteLine($"API response received: {response?.ToString()}");

                if (response?.Success == true)
                {
                    // Token'ı session'a kaydet
                    SessionExtensions.SetString(HttpContext.Session, "JWTToken", response.Token?.ToString() ?? "");
                    SessionExtensions.SetString(HttpContext.Session, "RefreshToken", response.RefreshToken?.ToString() ?? "");

                    // Kullanıcı bilgilerini session'a kaydet
                    var user = response.User;
                    SessionExtensions.SetString(HttpContext.Session, "UserId", user.Id.ToString());
                    SessionExtensions.SetString(HttpContext.Session, "Username", user.Username ?? "");
                    SessionExtensions.SetString(HttpContext.Session, "UserFullName", $"{user.FirstName ?? ""} {user.LastName ?? ""}");
                    SessionExtensions.SetString(HttpContext.Session, "UserRole", user.Role ?? "");

                    // Cookie authentication
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.Username ?? ""),
                        new Claim(ClaimTypes.GivenName, user.FirstName ?? ""),
                        new Claim(ClaimTypes.Surname, user.LastName ?? ""),
                        new Claim(ClaimTypes.Email, user.Email ?? ""),
                        new Claim(ClaimTypes.Role, user.Role ?? "")
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = model.RememberMe,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddHours(8)
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
                        new ClaimsPrincipal(claimsIdentity), authProperties);

                    Console.WriteLine($"Login successful for user: {model.Username}");
                    TempData["Success"] = "Giriş başarılı!";
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    var errorMessage = response?.Message ?? "Giriş başarısız";
                    Console.WriteLine($"Login failed for user {model.Username}: {errorMessage}");
                    ModelState.AddModelError(string.Empty, errorMessage);
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP request error during login for user: {model.Username} - {ex.Message}");
                ModelState.AddModelError(string.Empty, "API sunucusuna bağlanılamıyor. Lütfen daha sonra tekrar deneyin.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error during login for user: {model.Username} - {ex.Message}");
                ModelState.AddModelError(string.Empty, "Giriş sırasında bir hata oluştu. Lütfen daha sonra tekrar deneyin.");
            }

            return View(model);
        }

        [HttpPost("logout")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            try
            {
                // API'ye logout isteği gönder
                await _apiService.PostAsync<object, object>("api/auth/logout", new { });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during logout API call: {ex.Message}");
                // Hata olsa bile devam et
            }

            // Session'ı temizle
            HttpContext.Session.Clear();

            // Cookie'yi temizle
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            TempData["Success"] = "Çıkış başarılı!";
            return RedirectToAction("Login");
        }

        [HttpGet("profile")]
        public async Task<IActionResult> Profile()
        {
            try
            {
                var user = await _apiService.GetAsync<UserInfoViewModel>("api/auth/current-user");
                if (user != null)
                {
                    var profileViewModel = new UserProfileViewModel
                    {
                        Id = user.Id,
                        Username = user.Username ?? "",
                        FirstName = user.FirstName ?? "",
                        LastName = user.LastName ?? "",
                        Email = user.Email ?? "",
                        Phone = user.Phone ?? "",
                        Role = user.Role ?? "",
                        BranchName = user.BranchName ?? "",
                        EmployeeName = user.EmployeeName ?? "",
                        IsActive = user.IsActive
                    };

                    return View(profileViewModel);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting user profile: {ex.Message}");
                TempData["Error"] = "Profil bilgileri alınamadı";
            }

            return RedirectToAction("Login");
        }

        [HttpGet("change-password")]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost("change-password")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            Console.WriteLine("ChangePassword called");
            
            if (ModelState.IsValid)
            {
                try
                {
                    var changePasswordDto = new
                    {
                        CurrentPassword = model.CurrentPassword,
                        NewPassword = model.NewPassword,
                        ConfirmPassword = model.ConfirmPassword
                    };

                    Console.WriteLine("Calling API with change password data");
                    
                    var response = await _apiService.PostAsync<object, ChangePasswordResponseViewModel>("api/auth/change-password", changePasswordDto);
                    
                    Console.WriteLine($"API response received: {response?.ToString()}");

                    if (response?.Success == true)
                    {
                        TempData["Success"] = "Şifre başarıyla değiştirildi!";
                        return RedirectToAction("Profile");
                    }
                    else
                    {
                        var errorMessage = response?.Message ?? "Şifre değiştirme başarısız";
                        Console.WriteLine($"Password change failed: {errorMessage}");
                        ModelState.AddModelError(string.Empty, errorMessage);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error during password change: {ex.Message}");
                    ModelState.AddModelError(string.Empty, "Şifre değiştirme sırasında bir hata oluştu");
                }
            }
            else
            {
                Console.WriteLine("ChangePassword called with invalid model state");
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Model error: {error.ErrorMessage}");
                }
            }

            return View(model);
        }

        private IActionResult RedirectToLocal(string? returnUrl)
        {
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
} 