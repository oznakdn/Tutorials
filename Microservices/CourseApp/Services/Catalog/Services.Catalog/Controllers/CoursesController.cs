using CourseApp.Shared.ControllerBases;
using Microsoft.AspNetCore.Mvc;
using Services.Catalog.Dtos.CourseDtos;
using Services.Catalog.Services;

namespace Services.Catalog.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class CoursesController : CustomBaseController
    {
        private readonly ICourseService courseService;

        public CoursesController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await courseService.GetAllAsync();
            return CreateActionResultInstance(result);
        }

        [HttpGet("{courseId}",Name = "GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(string courseId)
        {
            var response = await courseService.GetByIdAsync(courseId);
            return CreateActionResultInstance(response);

        }


        //[Route("api/[controller]/GetAllByUserId/{userId}")]
        [HttpGet("{userId}", Name = "GetAllByUserIdAsync")]
        public async Task<IActionResult> GetAllByUserIdAsync(string userId)
        {
            var response = await courseService.GetAllUserIdAsync(userId);
            return CreateActionResultInstance(response);

        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CourseCreateDto courseCreate)
        {
            var result = await courseService.CreateAsync(courseCreate);
            return CreateActionResultInstance(result);
        }

        [HttpPut]
        public async Task<IActionResult> CreateAsync([FromBody] CourseUpdateDto courseUpdate)
        {
            var result = await courseService.UpdateAsync(courseUpdate);
            return CreateActionResultInstance(result);
        }

        [HttpDelete("{courseId}")]
        public async Task<IActionResult> DeleteAsync(string courseId)
        {
            var result = await courseService.DeleteAsync(courseId);
            return CreateActionResultInstance(result);
        }


    }
}
