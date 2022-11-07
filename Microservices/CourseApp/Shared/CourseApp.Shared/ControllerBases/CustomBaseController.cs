using CourseApp.Shared.Results;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Shared.ControllerBases
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomBaseController:ControllerBase
    {
        public IActionResult CreateActionResultInstance<T>(Response<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
