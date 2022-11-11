using CourseApp.Identity.Dtos;
using CourseApp.Identity.Results;

namespace CourseApp.Identity.Services.Abstracts
{
    public interface IUserService
    {
        Task<Response<List<UserDto>>> GetAllUsersAsync();
        Task<Response<UserDto>> GetUsersAsync(string username);
    }
}
