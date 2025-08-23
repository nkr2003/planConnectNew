using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using EventManagement.Api.Models;
using EventManagement.DTOs;
using EventManagement.Helpers;
using EventManagement.Data;
using EventManagement.Services;
using EventManagement.DTOs.AuthDtos;
using EventManagement.DTOs.UserDtos;


namespace EventManagement.Controllers.AuthModule
{
    [Route("api/auth")] //  api/Auth
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly JwtSettings _jwtSettings;
        public AuthController(ApplicationDbContext context , IMapper mapper,
                                ITokenService tokenService , IOptions<JwtSettings> jwtSetting)
        {
            _context = context; 
            _mapper = mapper;
            _tokenService = tokenService;
            _jwtSettings = jwtSetting.Value;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody]RegisterDto registerDto)
        {
            var user = _context.Users.FirstOrDefault(u=>u.Email == registerDto.Email);
            if (user != null)
            {
                return Conflict("Email already exists. ");
            }

            var userModel = _mapper.Map<User>(registerDto);
            _context.Users.Add(userModel);
            await _context.SaveChangesAsync();
            return Ok(_mapper.Map<UserResponseDto>(userModel));

        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody]LoginDto loginDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u=>u.Email ==  loginDto.Email);
            if(user == null)
            {
                return NotFound($"No user found with this email {loginDto.Email}");
            }

            if (user.PasswordHash != loginDto.PasswordHash)
            {
                return Unauthorized("Invalid password");
            }


            var acessToken = _tokenService.GenerateJwtToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();
            var accessTokenExpirationTime = DateTime.Now.AddMinutes(_jwtSettings.AccessTokenExpirationMinutes);
            var refreshTokenExpirationTime = DateTime.Now.AddDays(_jwtSettings.RefreshTokenExpirationDays);
            user.RefreshTokenExpiry = refreshTokenExpirationTime;
            user.RefreshToken = refreshToken;
            user.LastLogin = DateTime.Now;
            await _context.SaveChangesAsync();
            return Ok(
                new LoginResponseDto
                {
                    AccessToken = acessToken,
                    RefreshToken = refreshToken,
                    AccessTokenExpiration = accessTokenExpirationTime,
                    RefreshTokenExpiration = refreshTokenExpirationTime,
                    UserId = user.UserId 
                });
        }

        [HttpPost("logout/{userId}")]
        public async Task<IActionResult> LogoutUser([FromRoute]int userId)
        {
           
            
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
            if (user == null)
            {
                return NotFound($"No user found with this email {userId}");
            }
            user.RefreshToken = null;
            user.RefreshTokenExpiry = null;
            await _context.SaveChangesAsync();
            return Ok("User Logged out Successfully.");
        }

        // GET api/User/role-status/{id}
        [HttpGet("role-status/{id}")]
        public async Task<ActionResult<string>> GetUserRoleStatus(int id)
        {
            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.UserId == id);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            return Ok(user.RoleId == 1 ? "Admin" : user.RoleId == 2 ? "User" : "Unknown Role");
        }





    }
}
