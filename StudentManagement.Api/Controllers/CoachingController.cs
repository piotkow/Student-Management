using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models.Entities;
using StudentManagement.Services.Interfaces;

namespace StudentManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachingController : ControllerBase
    {
        private readonly ICoachingService _coachingService;

        public CoachingController(ICoachingService coachingService)
        {
            _coachingService = coachingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coaching>>> GetCoaches()
        {
            var coaches = await _coachingService.GetCoachesAsync();
            return Ok(coaches);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Coaching>> GetCoach(int id)
        {
            var coach = await _coachingService.GetCoachByIdAsync(id);

            if (coach == null)
            {
                return NotFound();
            }

            return Ok(coach);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoach(int id, Coaching coach)
        {
            if (id != coach.CoachingID)
            {
                return BadRequest();
            }

            await _coachingService.UpdateCoachAsync(coach);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Coaching>> PostCoach(Coaching coach)
        {
            await _coachingService.InsertCoachAsync(coach);

            return CreatedAtAction("GetCoach", new { id = coach.CoachingID }, coach);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoach(int id)
        {
            await _coachingService.DeleteCoachAsync(id);

            return NoContent();
        }
    }

}
