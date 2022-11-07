using CourseApp.Shared.Results;
using Services.Catalog.Dtos.CourseDtos;

namespace Services.Catalog.Services
{
    public interface ICourseService
    {
        Task<Response<List<CourseDto>>> GetAllAsync();
        Task<Response<CourseDto>> GetByIdAsync(string courseId);
        Task<Response<List<CourseDto>>> GetAllUserIdAsync(string userId);
        Task<Response<CourseDto>> CreateAsync(CourseCreateDto createDto);
        Task<Response<NoContentResponse>> UpdateAsync(CourseUpdateDto updateDto);
        Task<Response<NoContentResponse>> DeleteAsync(string courseId);
    }
}
