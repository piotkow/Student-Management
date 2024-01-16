using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models.Entities;
using StudentManagement.Services.Interfaces;

namespace StudentManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCourseController : ControllerBase
    {
        private readonly IUserCourseService _userCourseService;

        public UserCourseController(IUserCourseService userCourseService)
        {
            _userCourseService = userCourseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserCourse>>> GetUserCourses()
        {
            var userCourses = await _userCourseService.GetUserCoursesAsync();
            return Ok(userCourses);
        }

        [HttpGet("{userId}/{courseId}")]
        public async Task<ActionResult<UserCourse>> GetUserCourse(int userId, int courseId)
        {
            var userCourse = await _userCourseService.GetUserCourseByIdAsync(userId, courseId);

            if (userCourse == null)
            {
                return NotFound();
            }

            return Ok(userCourse);
        }

        [HttpPut("{userId}/{courseId}")]
        public async Task<IActionResult> PutUserCourse(int userId, int courseId, UserCourse userCourse)
        {
            if (userId != userCourse.UserID || courseId != userCourse.CourseID)
            {
                return BadRequest();
            }

            await _userCourseService.UpdateUserCourseAsync(userCourse);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<UserCourse>> PostUserCourse(UserCourse userCourse)
        {
            await _userCourseService.InsertUserCourseAsync(userCourse);

            return CreatedAtAction("GetUserCourse", new { userId = userCourse.UserID, courseId = userCourse.CourseID }, userCourse);
        }

        [HttpDelete("{userId}/{courseId}")]
        public async Task<IActionResult> DeleteUserCourse(int userId, int courseId)
        {
            await _userCourseService.DeleteUserCourseAsync(userId, courseId);

            return NoContent();
        }
    }
}
