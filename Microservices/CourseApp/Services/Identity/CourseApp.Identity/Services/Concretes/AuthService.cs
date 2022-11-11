using CourseApp.Identity.Data;
using CourseApp.Identity.Dtos;
using CourseApp.Identity.Models;
using CourseApp.Identity.Results;
using CourseApp.Identity.Services.Abstracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CourseApp.Identity.Services.Concretes
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly ApplicationDbContext _context;

        public AuthService(UserManager<ApplicationUser> userManager, ITokenService tokenService, ApplicationDbContext context)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _context = context;
        }


        /// <summary>
        /// When registerDto model is valid it records a new user. 
        /// </summary>
        /// <param name="registerDto"></param>
        /// <returns></returns>
        public async Task<Response<UserDto>> RegisterAsync(RegisterDto registerDto)
        {
            var newUser = new ApplicationUser
            {
                Email = registerDto.Email,
                UserName = registerDto.UserName,
                City = registerDto.City
            };

            var result = await _userManager.CreateAsync(newUser, registerDto.Password);

            if (result.Succeeded)
                return Response<UserDto>.Success(new UserDto { Id = newUser.Id, Email = newUser.Email, UserName = newUser.UserName, City = newUser.City }, 200);

            return Response<UserDto>.Fail(new Error(result.Errors.Select(x => x.Description).ToList()),404);
        }

        /// <summary>
        /// When user could be login it creates an access token and refresh token
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>

        public async Task<Response<TokenDto>> LoginAsync(LoginDto loginDto)
        {
            if (loginDto is null)
                throw new ArgumentNullException(nameof(loginDto));

            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user is null)
                return Response<TokenDto>.Fail("Email or Password is invalid!", 404);

            if (!await _userManager.CheckPasswordAsync(user, loginDto.Password))
                return Response<TokenDto>.Fail("Email or Password is invalid!", 404);


            var token = _tokenService.CreateToken(user);
            var refreshToken = await _context.RefreshTokens.Where(x => x.UserId == user.Id).SingleOrDefaultAsync();

            if (refreshToken is null)
            {
                await _context.RefreshTokens.AddAsync(new ApplicationUserRefreshToken
                {
                    UserId = user.Id,
                    Token = token.RefreshToken,
                    Expiration = token.RefreshTokenExpiration
                });
            }
            else
            {
                refreshToken.Token = token.RefreshToken;
                refreshToken.Expiration = token.RefreshTokenExpiration;
            }
            await _context.SaveChangesAsync();
            return Response<TokenDto>.Success(token, 200);
        }


        /// <summary>
        /// When user is login again, it creates a new refresh token
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        
        public async Task<Response<TokenDto>> RefreshLoginAsync(string refreshToken)
        {
            var existRefreshToken = await _context.RefreshTokens.Where(r => r.Token == refreshToken).FirstOrDefaultAsync();

            if (existRefreshToken is null)
                return Response<TokenDto>.Fail("Refresh token not found!", 404);

            var user = await _userManager.FindByIdAsync(existRefreshToken.UserId);
            if (user is null)
                return Response<TokenDto>.Fail("User not found", 404);


            var token = _tokenService.CreateToken(user);
            existRefreshToken.Token = token.RefreshToken;
            existRefreshToken.Expiration = token.AccessTokenExpiration;

            await _context.SaveChangesAsync();
            return Response<TokenDto>.Success(token, 200);
        }



        /// <summary>
        /// When user is logout it removes a the refresh token
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        public async Task<Response<string>> LogoutAsync(string refreshToken)
        {
            var existRefreshToken = await _context.RefreshTokens.Where(r => r.Token == refreshToken).FirstOrDefaultAsync();

            if (existRefreshToken is null)
                return Response<string>.Fail("Refresh token not found", 404);

            _context.RefreshTokens.Remove(existRefreshToken);
            await _context.SaveChangesAsync();

            return Response<string>.Success(200);
        }
    }
}
