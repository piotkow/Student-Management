using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Models.Entities;
using StudentManagement.Services.DTOs.User;
using StudentManagement.Services.Interfaces;
using StudentManagment.Data;

namespace StudentManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserRequest userReq)
        {
            await _userService.UpdateUserAsync(id, userReq);

            return Ok(userReq);
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<UserRequest>> PostUser([FromBody] UserRequest userReq)
        {
            var insertedUser = await _userService.InsertUserAsync(userReq);

            return CreatedAtAction(nameof(GetUser), new { id = insertedUser.UserID }, insertedUser);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);

            return Ok();
        }
    }
}
