using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Models.Entities;
using StudentManagement.Services.DTOs.Grade;
using StudentManagement.Services.Interfaces;
using StudentManagment.Data;

namespace StudentManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly IGradeService _gradeService;

        public GradesController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        // GET: api/Grades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grade>>> GetGrades()
        {
            var grades = await _gradeService.GetGradesAsync();
            return Ok(grades);
        }

        // GET: api/Grades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Grade>> GetGrade(int id)
        {
            var grade = await _gradeService.GetGradeByIdAsync(id);

            if (grade == null)
            {
                return NotFound();
            }

            return Ok(grade);
        }

        // PUT: api/Grades/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrade(int id, [FromBody]GradeRequest gradeReq)
        {
            await _gradeService.UpdateGradeAsync(id, gradeReq);

            return Ok(gradeReq);
        }

        // POST: api/Grades
        [HttpPost]
        public async Task<ActionResult<Grade>> PostGrade([FromBody]GradeRequest gradeReq)
        {
            var insertedGrade = await _gradeService.InsertGradeAsync(gradeReq);

            return CreatedAtAction("GetGrade", new { id = insertedGrade.GradeID }, insertedGrade);
        }

        // DELETE: api/Grades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrade(int id)
        {
            await _gradeService.DeleteGradeAsync(id);

            return NoContent();
        }
    }
}

