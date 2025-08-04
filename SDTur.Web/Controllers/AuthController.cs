using Microsoft.AspNetCore.Mvc;
using SDTur.Web.Models.Auth;
using SDTur.Web.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

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
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost("login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                try
                {
                    var loginDto = new
                    {
                        Username = model.Username,
                        Password = model.Password,
                        RememberMe = model.RememberMe
                    };

                    var response = await _apiService.PostAsync<object, dynamic>("api/auth/login", loginDto);

                    if (response != null && response.Success)
                    {
                        // Token'ı session'a kaydet
                        HttpContext.Session.SetString("JWTToken", response.Token);
                        HttpContext.Session.SetString("RefreshToken", response.RefreshToken);

                        // Kullanıcı bilgilerini session'a kaydet
                        var user = response.User;
                        HttpContext.Session.SetString("UserId", user.Id.ToString());
                        HttpContext.Session.SetString("Username", user.Username);
                        HttpContext.Session.SetString("UserFullName", $"{user.FirstName} {user.LastName}");
                        HttpContext.Session.SetString("UserRole", user.Role);

                        // Cookie authentication
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                            new Claim(ClaimTypes.Name, user.Username),
                            new Claim(ClaimTypes.GivenName, user.FirstName),
                            new Claim(ClaimTypes.Surname, user.LastName),
                            new Claim(ClaimTypes.Email, user.Email ?? ""),
                            new Claim(ClaimTypes.Role, user.Role)
                        };

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var authProperties = new AuthenticationProperties
                        {
                            IsPersistent = model.RememberMe,
                            ExpiresUtc = DateTimeOffset.UtcNow.AddHours(8)
                        };

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
                            new ClaimsPrincipal(claimsIdentity), authProperties);

                        TempData["Success"] = "Giriş başarılı!";
                        return RedirectToLocal(returnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, response?.Message ?? "Giriş başarısız");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Giriş sırasında bir hata oluştu");
                }
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
                await _apiService.PostAsync<object, object>("api/auth/logout", null);
            }
            catch
            {
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
                var user = await _apiService.GetAsync<dynamic>("api/auth/current-user");
                if (user != null)
                {
                    var profileViewModel = new UserProfileViewModel
                    {
                        Id = user.Id,
                        Username = user.Username,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        Phone = user.Phone,
                        Role = user.Role,
                        BranchName = user.BranchName,
                        EmployeeName = user.EmployeeName,
                        IsActive = user.IsActive
                    };

                    return View(profileViewModel);
                }
            }
            catch
            {
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

                    var response = await _apiService.PostAsync<object, dynamic>("api/auth/change-password", changePasswordDto);

                    if (response != null && response.Success)
                    {
                        TempData["Success"] = "Şifre başarıyla değiştirildi!";
                        return RedirectToAction("Profile");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, response?.Message ?? "Şifre değiştirme başarısız");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Şifre değiştirme sırasında bir hata oluştu");
                }
            }

            return View(model);
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
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