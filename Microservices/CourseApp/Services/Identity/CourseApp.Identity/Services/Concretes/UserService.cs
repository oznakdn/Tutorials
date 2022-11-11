using CourseApp.Identity.Dtos;
using CourseApp.Identity.Models;
using CourseApp.Identity.Results;
using CourseApp.Identity.Services.Abstracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CourseApp.Identity.Services.Concretes
{
    public class UserService: IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task<Response<List<UserDto>>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            return Response<List<UserDto>>.Success((users.Select(u => new UserDto
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email,
                City = u.City
            }).ToList()), 200);

        }

        public async Task<Response<UserDto>> GetUsersAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user is null)
                return Response<UserDto>.Fail("User not found", 404);

            return Response<UserDto>.Success(new UserDto { Id = user.Id, UserName = user.UserName, Email = user.Email, City = user.City }, 200);
        }
    }
}
