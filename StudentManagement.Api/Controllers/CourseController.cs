using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models.Entities;
using StudentManagement.Services.DTOs.Course;
using StudentManagement.Services.Interfaces;

namespace StudentManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            var courses = await _courseService.GetCoursesAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id,[FromBody]CourseRequest courseReq)
        {
            await _courseService.UpdateCourseAsync(id,courseReq);

            return Ok(courseReq);
        }

        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse([FromBody]CourseRequest courseReq)
        {
            var insertedCourse = await _courseService.InsertCourseAsync(courseReq);

            return CreatedAtAction("GetCourse", new { id = insertedCourse.CourseID }, insertedCourse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            await _courseService.DeleteCourseAsync(id);

            return NoContent();
        }
    }

}
