using CourseApp.Identity.Dtos;
using CourseApp.Identity.Results;

namespace CourseApp.Identity.Services.Abstracts
{
    public interface IAuthService
    {

        Task<Response<UserDto>> RegisterAsync(RegisterDto registerDto);
        Task<Response<TokenDto>> LoginAsync(LoginDto loginDto);
        Task<Response<TokenDto>> RefreshLoginAsync(string refreshToken);
        Task<Response<string>> LogoutAsync(string refreshToken);
    }
}
