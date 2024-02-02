using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models.Entities;
using StudentManagement.Services.Interfaces;

namespace StudentManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseTrainingController : ControllerBase
    {
        private readonly ICourseTrainingService _courseTrainingService;

        public CourseTrainingController(ICourseTrainingService courseTrainingService)
        {
            _courseTrainingService = courseTrainingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseTraining>>> GetCourseTrainings()
        {
            var courseTrainings = await _courseTrainingService.GetCourseTrainingsAsync();
            return Ok(courseTrainings);
        }

        [HttpGet("{courseId}")]
        public async Task<ActionResult<IEnumerable<CourseTraining>>> GetCourseTrainingsByCourseId(int courseId)
        {
            var courseTrainings = await _courseTrainingService.GetCourseTrainingsByCourseIdAsync(courseId);
            return Ok(courseTrainings);
        }

        [HttpGet("{courseId}/{trainingId}")]
        public async Task<ActionResult<CourseTraining>> GetCourseTraining(int courseId, int trainingId)
        {
            var courseTraining = await _courseTrainingService.GetCourseTrainingByIdAsync(courseId, trainingId);

            if (courseTraining == null)
            {
                return NotFound();
            }

            return Ok(courseTraining);
        }

        [HttpPut("{courseId}/{trainingId}")]
        public async Task<IActionResult> PutCourseTraining(int courseId, int trainingId, CourseTraining courseTraining)
        {
            if (courseId != courseTraining.CourseID || trainingId != courseTraining.TrainingID)
            {
                return BadRequest();
            }

            await _courseTrainingService.UpdateCourseTrainingAsync(courseTraining);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<CourseTraining>> PostCourseTraining(CourseTraining courseTraining)
        {
            await _courseTrainingService.InsertCourseTrainingAsync(courseTraining);

            return CreatedAtAction("GetCourseTraining", new { courseId = courseTraining.CourseID, trainingId = courseTraining.TrainingID }, courseTraining);
        }

        [HttpDelete("{courseId}/{trainingId}")]
        public async Task<IActionResult> DeleteCourseTraining(int courseId, int trainingId)
        {
            await _courseTrainingService.DeleteCourseTrainingAsync(courseId, trainingId);

            return NoContent();
        }
    }

}
