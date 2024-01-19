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
            if (await _userService.AuthenticateUser(req) != null)
                {
                 var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("7e7355946837449c83f32d53cbe8f74849a36589b8b83b2e6f6a28c5e72e4e7d"));
                 var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                 var tokenOptions = new JwtSecurityToken(
                     issuer: "http://localhost:5249",
                     audience: "http://localhost:4200",
                     claims: new List<Claim>(),
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
