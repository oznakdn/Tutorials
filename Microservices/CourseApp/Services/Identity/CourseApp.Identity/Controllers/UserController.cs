using CourseApp.Identity.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult>GetUsers()
        {
            var response = await _userService.GetAllUsersAsync();

            return Ok(response);
        }

        [HttpGet("{userName}")]
        public async Task<IActionResult> GetUser(string userName)
        {
            var response = await _userService.GetUsersAsync(userName);

            if (!response.IsSuccessful)
                return BadRequest(response.Error);

            return Ok(response);
        }


    }
}
