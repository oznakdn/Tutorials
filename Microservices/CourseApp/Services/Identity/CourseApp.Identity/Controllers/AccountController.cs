using CourseApp.Identity.Dtos;
using CourseApp.Identity.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Identity.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost(Name = "SignUp")]
        public async Task<IActionResult> SignUp([FromBody] RegisterDto registerDto)
        {
            var response = await _authService.RegisterAsync(registerDto);
            if(response.IsSuccessful)
            {
                return Ok(response.Data);
            }

            return BadRequest(response.Error);
        }

        [HttpPost(Name = "Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var response = await _authService.LoginAsync(loginDto);
            if (response.IsSuccessful)
            {
                return Ok(response.Data);
            }

            return BadRequest(response.Error);
        }

        [HttpPost(Name = "Logout")]
        public async Task<IActionResult>Logout(string refreshToken)
        {
            var response = await _authService.LogoutAsync(refreshToken);
            if (response.IsSuccessful)
            {
                return Ok(response.Data);
            }

            return BadRequest(response.Error.Errors.FirstOrDefault());

        }
    }
}
