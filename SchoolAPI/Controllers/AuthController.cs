using Microsoft.AspNetCore.Mvc;
using SchoolAPI.DTOs;
using SchoolAPI.Services;

namespace SchoolAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public ActionResult<AuthResponseDto> Register(RegisterDto dto)
        {
            var result = _authService.Register(dto);
            if (result == null)
                return BadRequest("Email already exists.");
            return Ok(result);
        }

        [HttpPost("login")]
        public ActionResult<AuthResponseDto> Login(LoginDto dto)
        {
            var result = _authService.Login(dto);
            if (result == null)
                return Unauthorized("Invalid email or password.");
            return Ok(result);
        }
    }
}