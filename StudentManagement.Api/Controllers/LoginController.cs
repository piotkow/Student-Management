using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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

        [HttpPost, Route("login")]
        public IActionResult Login(UserLoginRequest user)
        {
            try
            {
                if (string.IsNullOrEmpty(user.Username) ||
                string.IsNullOrEmpty(user.Password))
                    return BadRequest("Username and/or Password not specified");
                if (_userService.AuthenticateUser(user) != null)
                {
                    var secretKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes("tokenKey"));
                    var signinCredentials = new SigningCredentials
                    (secretKey, SecurityAlgorithms.HmacSha256);
                    var jwtSecurityToken = new JwtSecurityToken(
                        issuer: "ABCXYZ",
                        audience: "http://localhost:44372",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(10),
                        signingCredentials: signinCredentials
                    );
                    return Ok(new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken));
                }
            }
            catch
            {
            }
            return Unauthorized();
        }
    }
}
