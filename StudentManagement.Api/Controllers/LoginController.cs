using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol.Plugins;
using StudentManagement.Models.Entities;
using StudentManagement.Services.DTOs.User;
using StudentManagement.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StudentManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;

        public LoginController (IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest req)
        { 
            User authenticatedUser = await _userService.AuthenticateUser(req);
            
            if (authenticatedUser != null)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("7e7355946837449c83f32d53cbe8f74849a36589b8b83b2e6f6a28c5e72e4e7d"));
                var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, authenticatedUser.UserID.ToString()),
                    new Claim(ClaimTypes.Name, authenticatedUser.Username), // Add username as a claim
                    new Claim("userID", authenticatedUser.UserID.ToString()),
                    new Claim("role", authenticatedUser.Role.ToString()), // Assuming Role is an enum
                    new Claim("email", authenticatedUser.Email),
                    new Claim("firstName", authenticatedUser.FirstName),
                    new Claim("lastName", authenticatedUser.LastName),
                    new Claim("dateOfBirth", authenticatedUser.DateOfBirth.ToString("yyyy-MM-dd")), // Adjust the date format as needed
                    new Claim("avatar", authenticatedUser.Avatar),
                    new Claim("phone", authenticatedUser.Phone),
                };

                var tokenOptions = new JwtSecurityToken(
                     issuer: "http://localhost:5249",
                     audience: "http://localhost:4200",
                     claims: claims,
                     expires: DateTime.Now.AddMinutes(5),
                     signingCredentials: credentials
                     );

                 string token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                 return Ok(new LoginResponse(token));
                }

            return Unauthorized();
            }
    }
}
