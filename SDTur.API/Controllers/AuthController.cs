using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs.System.Auth;
using SDTur.Application.Services.System.Interfaces;

namespace SDTur.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.LoginAsync(loginDto);
            
            if (!result.Success)
                return Unauthorized(result);

            return Ok(result);
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<ActionResult> Logout()
        {
            var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (string.IsNullOrEmpty(token))
                return BadRequest("Token bulunamadı");

            var result = await _authService.LogoutAsync(token);
            return Ok(new { Success = result, Message = "Çıkış başarılı" });
        }

        [HttpPost("change-password")]
        [Authorize]
        public async Task<ActionResult> ChangePassword([FromBody] ChangePasswordDto changePasswordDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "0");
            if (userId == 0)
                return Unauthorized();

            var result = await _authService.ChangePasswordAsync(userId, changePasswordDto);
            
            if (!result)
                return BadRequest(new { Success = false, Message = "Şifre değiştirme başarısız" });

            return Ok(new { Success = true, Message = "Şifre başarıyla değiştirildi" });
        }

        [HttpGet("validate-token")]
        [Authorize]
        public async Task<ActionResult> ValidateToken()
        {
            return Ok(new { Valid = true, Message = "Token geçerli" });
        }

        [HttpGet("current-user")]
        [Authorize]
        public async Task<ActionResult<UserInfoDto>> GetCurrentUser()
        {
            var userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "0");
            if (userId == 0)
                return Unauthorized();

            var user = await _authService.GetCurrentUserAsync(userId);
            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }
} 