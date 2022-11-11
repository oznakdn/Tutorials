using CourseApp.Identity.Dtos;
using CourseApp.Identity.Models;

namespace CourseApp.Identity.Services.Abstracts
{
    public interface ITokenService
    {
        TokenDto CreateToken(ApplicationUser user);
        string CreateRefreshToken();
    }
}
