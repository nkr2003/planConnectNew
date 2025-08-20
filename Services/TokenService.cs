using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using EventManagement.Api.Models;
using EventManagement.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EventManagement.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtSettings _jwtSettings;  
        public TokenService(IOptions<JwtSettings> jwtSettings) {
            _jwtSettings = jwtSettings.Value; // Initialize JwtSettings from configuration
        }

        //This function generates a JWT token for the user 
        public string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name , user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier , user.UserId.ToString()),
                new Claim(ClaimTypes.Role , user.RoleId.ToString())
               
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_jwtSettings.Key)); // Use a secure key
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.AccessTokenExpirationMinutes), // Set token expiry time
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token); // Generate the JWT token
        }

        public string GenerateRefreshToken()
        {
           return Guid.NewGuid().ToString(); // Generate a new refresh token using a GUID
        }
    }
}
