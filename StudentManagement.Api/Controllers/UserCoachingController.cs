using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models.Entities;
using StudentManagement.Services.Interfaces;

namespace StudentManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCoachingController : ControllerBase
    {
        private readonly IUserCoachingService _userCoachingService;

        public UserCoachingController(IUserCoachingService userCoachingService)
        {
            _userCoachingService = userCoachingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserCoaching>>> GetUserCoachings()
        {
            var userCoachings = await _userCoachingService.GetUserCoachingsAsync();
            return Ok(userCoachings);
        }

        [HttpGet("{userId}/{coachingId}")]
        public async Task<ActionResult<UserCoaching>> GetUserCoaching(int userId, int coachingId)
        {
            var userCoaching = await _userCoachingService.GetUserCoachingByIdAsync(userId, coachingId);

            if (userCoaching == null)
            {
                return NotFound();
            }

            return Ok(userCoaching);
        }

        [HttpPut("{userId}/{coachingId}")]
        public async Task<IActionResult> PutUserCoaching(int userId, int coachingId, UserCoaching userCoaching)
        {
            if (userId != userCoaching.UserID || coachingId != userCoaching.CoachingID)
            {
                return BadRequest();
            }

            await _userCoachingService.UpdateUserCoachingAsync(userCoaching);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<UserCoaching>> PostUserCoaching(UserCoaching userCoaching)
        {
            await _userCoachingService.InsertUserCoachingAsync(userCoaching);

            return CreatedAtAction("GetUserCoaching", new { userId = userCoaching.UserID, coachingId = userCoaching.CoachingID }, userCoaching);
        }

        [HttpDelete("{userId}/{coachingId}")]
        public async Task<IActionResult> DeleteUserCoaching(int userId, int coachingId)
        {
            await _userCoachingService.DeleteUserCoachingAsync(userId, coachingId);

            return NoContent();
        }
    }
}

