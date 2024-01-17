using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StudentManagement.Services.DTOs.User;
using StudentManagement.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Logging;


namespace StudentManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        private readonly ILogger<LoginController> _logger;

        public LoginController(ITokenService tokenService, IUserService userService, ILogger<LoginController> logger)
        {
            _tokenService = tokenService;
            _userService = userService;
            _logger = logger;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest userLoginRequest)
        {
            try
            {
                // Validate user credentials
                var user = await _userService.AuthenticateUser(userLoginRequest);

                if (user == null)
                {
                    return Unauthorized(new { Message = "Invalid username or password." });
                }

                // Generate a JWT token
                var token = _tokenService.GenerateToken(user);

                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "An error occurred during login.");

                // Return a more detailed error message if needed
                return StatusCode(500, new { Message = "An error occurred during login. See logs for details." });
            }

        }
    }
}
