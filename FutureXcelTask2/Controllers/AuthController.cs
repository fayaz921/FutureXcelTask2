using FutureXcelTask2.Models;
using FutureXcelTask2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FutureXcelTask2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authService;

        public AuthController(IAuthServices authService)
        {
            _authService = authService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] SignupRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _authService.Signup(request);

            if (user == null)
                return Conflict(new { message = "User already exists" });

            var token = await _authService.Login(new LoginRequest
            {
                Email = request.Email,
                Password = request.Password
            });

            // Set HttpOnly cookie
            SetTokenCookie(token!);

            return Ok(new AuthResponse
            {
                Token = token!,
                Email = user.Email,
                Name = user.Name
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var token = await _authService.Login(request);

            if (token == null)
                return Unauthorized(new { message = "Invalid credentials" });

            var user = await _authService.GetUserByEmail(request.Email);

            // Set HttpOnly cookie
            SetTokenCookie(token);

            return Ok(new AuthResponse
            {
                Token = token,
                Email = user!.Email,
                Name = user.Name
            });
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("token");
            return Ok(new { message = "Logged out successfully" });
        }

        private void SetTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true, // Only send over HTTPS
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddDays(7)
            };

            Response.Cookies.Append("token", token, cookieOptions);
        }
    }
}
