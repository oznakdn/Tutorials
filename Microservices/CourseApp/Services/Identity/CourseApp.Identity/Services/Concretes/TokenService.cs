using CourseApp.Identity.Dtos;
using CourseApp.Identity.Models;
using CourseApp.Identity.Services.Abstracts;
using CourseApp.Identity.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CourseApp.Identity.Services.Concretes
{
    public class TokenService: ITokenService
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly TokenSettings _tokenSettings;

        public TokenService(UserManager<ApplicationUser> userManager, IOptions<TokenSettings>tokenSettings)
        {
            _userManager = userManager;
            _tokenSettings = tokenSettings.Value;
        }

        private IEnumerable<Claim> GetClaims(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                 new Claim(ClaimTypes.NameIdentifier,user.Id),
                 new Claim(ClaimTypes.Email,user.Email),
                 new Claim(ClaimTypes.Name,user.UserName),
                 new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            return claims;
        }

        public TokenDto CreateToken(ApplicationUser user)
        {
            var accessTokenExpiration = DateTime.Now.AddMinutes(_tokenSettings.AccessTokenExpiration);
            var refreshTokenExpiration = DateTime.Now.AddMinutes(_tokenSettings.RefreshTokenExpiration);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.SecurityKey));
            var signInCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            JwtSecurityToken jwtSecurityToken = new(

                 issuer:_tokenSettings.Issuer,
                 audience:_tokenSettings.Audience,
                 expires:accessTokenExpiration,
                 notBefore:DateTime.Now,
                 claims:GetClaims(user),
                 signingCredentials: signInCredentials
                );

            var handler = new JwtSecurityTokenHandler();
            var token = handler.WriteToken(jwtSecurityToken);

            return new TokenDto
            {
                 AccessToken = token,
                 AccessTokenExpiration = accessTokenExpiration,
                 RefreshToken = CreateRefreshToken(),
                 RefreshTokenExpiration = refreshTokenExpiration
            };
            
        }

        public string CreateRefreshToken()
        {
            var bytes = new byte[32];

            using var number = RandomNumberGenerator.Create();
            number.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }
    }
}
