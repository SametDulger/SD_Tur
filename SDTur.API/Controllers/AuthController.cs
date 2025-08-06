using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs.System.Auth;
using SDTur.Application.Services.System.Interfaces;
using Microsoft.AspNetCore.Authorization;
using SDTur.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace SDTur.API.Controllers
{
    /// <summary>
    /// Kimlik doğrulama ve yetkilendirme işlemleri için API endpoint'leri
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "Authentication")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;
        private readonly SDTurDbContext _context;

        public AuthController(IAuthService authService, ILogger<AuthController> logger, SDTurDbContext context)
        {
            _authService = authService;
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// API'nin çalışıp çalışmadığını test eder
        /// </summary>
        /// <returns>API durumu ve zaman damgası</returns>
        /// <response code="200">API başarıyla çalışıyor</response>
        [HttpGet("test")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Test()
        {
            _logger.LogInformation("API Test endpoint called");
            return Ok(new { message = "API is working!", timestamp = DateTime.UtcNow });
        }

        /// <summary>
        /// Veritabanındaki kullanıcıları kontrol eder (Debug amaçlı)
        /// </summary>
        /// <returns>Kullanıcı listesi ve sayısı</returns>
        /// <response code="200">Kullanıcılar başarıyla listelendi</response>
        /// <response code="500">Sunucu hatası</response>
        [HttpGet("check-users")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CheckUsers()
        {
            try
            {
                var users = _context.Users.Where(u => !u.IsDeleted).ToList();
                var userCount = users.Count;
                
                _logger.LogInformation("Found {UserCount} users in database", userCount);
                
                var userList = users.Select(u => new
                {
                    Id = u.Id,
                    Username = u.Username,
                    Email = u.Email,
                    Role = u.Role,
                    IsActive = u.IsActive,
                    CreatedDate = u.CreatedDate,
                    PasswordHash = u.Password?.Substring(0, Math.Min(20, u.Password?.Length ?? 0)) + "..." // İlk 20 karakteri göster
                }).ToList();

                return Ok(new
                {
                    UserCount = userCount,
                    Users = userList,
                    Message = $"Found {userCount} users in database"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking users");
                return StatusCode(500, new { message = "Error checking users", error = ex.Message });
            }
        }

        /// <summary>
        /// Kullanıcı şifrelerini kontrol eder (Debug amaçlı)
        /// </summary>
        /// <returns>Şifre detayları</returns>
        /// <response code="200">Şifre detayları başarıyla alındı</response>
        /// <response code="500">Sunucu hatası</response>
        [HttpGet("check-passwords")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CheckPasswords()
        {
            try
            {
                var users = _context.Users.Where(u => !u.IsDeleted).ToList();
                var userCount = users.Count;
                
                _logger.LogInformation("Checking passwords for {UserCount} users", userCount);
                
                var userList = users.Select(u => new
                {
                    Id = u.Id,
                    Username = u.Username,
                    Email = u.Email,
                    Role = u.Role,
                    IsActive = u.IsActive,
                    PasswordHash = u.Password,
                    PasswordLength = u.Password?.Length ?? 0,
                    IsBCryptHash = u.Password?.StartsWith("$2") ?? false,
                    CreatedDate = u.CreatedDate,
                    UpdatedDate = u.UpdatedDate
                }).ToList();

                return Ok(new
                {
                    UserCount = userCount,
                    Users = userList,
                    Message = $"Password details for {userCount} users"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking passwords");
                return StatusCode(500, new { message = "Error checking passwords", error = ex.Message });
            }
        }

        /// <summary>
        /// Şifre testi yapar (Debug amaçlı)
        /// </summary>
        /// <param name="loginDto">Giriş bilgileri</param>
        /// <returns>Şifre doğrulama sonucu</returns>
        /// <response code="200">Şifre doğrulama sonucu</response>
        /// <response code="400">Geçersiz giriş bilgileri</response>
        [HttpPost("test-password")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> TestPassword([FromBody] LoginDto loginDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Username == loginDto.Username && !u.IsDeleted);

                if (user == null)
                {
                    return Ok(new
                    {
                        Success = false,
                        Message = "Kullanıcı bulunamadı",
                        Username = loginDto.Username,
                        UserExists = false
                    });
                }

                var isPasswordValid = BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password);

                return Ok(new
                {
                    Success = isPasswordValid,
                    Message = isPasswordValid ? "Şifre doğru" : "Şifre yanlış",
                    Username = loginDto.Username,
                    UserExists = true,
                    UserId = user.Id,
                    UserEmail = user.Email,
                    UserRole = user.Role,
                    IsActive = user.IsActive,
                    PasswordHash = user.Password,
                    IsBCryptHash = user.Password.StartsWith("$2")
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error testing password for user {Username}", loginDto.Username);
                return StatusCode(500, new { message = "Error testing password", error = ex.Message });
            }
        }

        /// <summary>
        /// Kullanıcı girişi yapar
        /// </summary>
        /// <param name="loginDto">Giriş bilgileri</param>
        /// <returns>JWT token ve kullanıcı bilgileri</returns>
        /// <response code="200">Başarılı giriş</response>
        /// <response code="400">Geçersiz giriş bilgileri</response>
        /// <response code="401">Kimlik doğrulama başarısız</response>
        [HttpPost("login")]
        [ProducesResponseType(typeof(LoginResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _authService.LoginAsync(loginDto);
                if (result == null)
                {
                    return Unauthorized(new { message = "Geçersiz kullanıcı adı veya şifre" });
                }

                _logger.LogInformation("User {Username} logged in successfully", loginDto.Username);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during login for user {Username}", loginDto.Username);
                return StatusCode(500, new { message = "Giriş sırasında hata oluştu", error = ex.Message });
            }
        }

        /// <summary>
        /// Kullanıcı çıkışı yapar
        /// </summary>
        /// <returns>Çıkış durumu</returns>
        /// <response code="200">Başarılı çıkış</response>
        /// <response code="401">Yetkilendirme gerekli</response>
        [HttpPost("logout")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Logout()
        {
            try
            {
                var username = User.Identity?.Name;
                _logger.LogInformation("User {Username} logged out", username);
                
                return Ok(new { message = "Başarıyla çıkış yapıldı" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during logout");
                return StatusCode(500, new { message = "Çıkış sırasında hata oluştu", error = ex.Message });
            }
        }

        /// <summary>
        /// Kullanıcı şifresini değiştirir
        /// </summary>
        /// <param name="changePasswordDto">Şifre değiştirme bilgileri</param>
        /// <returns>Şifre değiştirme durumu</returns>
        /// <response code="200">Şifre başarıyla değiştirildi</response>
        /// <response code="400">Geçersiz bilgiler</response>
        /// <response code="401">Yetkilendirme gerekli</response>
        [HttpPost("change-password")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto changePasswordDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "0");
                if (userId == 0)
                {
                    return Unauthorized(new { message = "Kullanıcı kimliği bulunamadı" });
                }

                var result = await _authService.ChangePasswordAsync(userId, changePasswordDto);
                if (!result)
                {
                    return BadRequest(new { message = "Mevcut şifre yanlış veya şifre değiştirme başarısız" });
                }

                _logger.LogInformation("Password changed successfully for user ID {UserId}", userId);
                return Ok(new { message = "Şifre başarıyla değiştirildi" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error changing password for user ID {UserId}", 
                    User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value);
                return StatusCode(500, new { message = "Şifre değiştirme sırasında hata oluştu", error = ex.Message });
            }
        }

        /// <summary>
        /// Mevcut kullanıcı bilgilerini getirir
        /// </summary>
        /// <returns>Kullanıcı bilgileri</returns>
        /// <response code="200">Kullanıcı bilgileri başarıyla alındı</response>
        /// <response code="401">Yetkilendirme gerekli</response>
        [HttpGet("current-user")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetCurrentUser()
        {
            try
            {
                var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                var username = User.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value;
                var role = User.FindFirst(System.Security.Claims.ClaimTypes.Role)?.Value;

                return Ok(new
                {
                    UserId = userId,
                    Username = username,
                    Role = role,
                    IsAuthenticated = User.Identity?.IsAuthenticated ?? false
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting current user");
                return StatusCode(500, new { message = "Kullanıcı bilgileri alınırken hata oluştu", error = ex.Message });
            }
        }
    }
} 