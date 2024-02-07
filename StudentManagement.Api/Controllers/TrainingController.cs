using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Models.Entities;
using StudentManagement.Services.DTOs.Training;
using StudentManagement.Services.Interfaces;
using StudentManagment.Data;

namespace StudentManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingsController : ControllerBase
    {
        private readonly ITrainingService _trainingService;

        public TrainingsController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        // GET: api/Trainings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Training>>> GetTrainings()
        {
            var trainings = await _trainingService.GetTrainingsAsync();
            return Ok(trainings);
        }

        // GET: api/Trainings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Training>> GetTraining(int id)
        {
            var training = await _trainingService.GetTrainingByIdAsync(id);

            if (training == null)
            {
                return NotFound();
            }

            return Ok(training);
        }

        // PUT: api/Trainings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTraining(int id, [FromBody]TrainingRequest trainingReq)
        {
            await _trainingService.UpdateTrainingAsync(id, trainingReq);

            return NoContent();
        }

        // POST: api/Trainings
        [HttpPost]
        public async Task<ActionResult<Training>> PostTraining([FromBody]TrainingRequest trainingReq)
        {
            var insertedTraining = await _trainingService.InsertTrainingAsync(trainingReq);

            return CreatedAtAction("GetTraining", new { id = insertedTraining.TrainingID }, insertedTraining);
        }

        // DELETE: api/Trainings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTraining(int id)
        {
            await _trainingService.DeleteTrainingAsync(id);

            return NoContent();
        }
    }
}

