using StudentManagement.Models.Entities;
using StudentManagement.Services.DTOs.Grade;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagement.Services.Interfaces
{
    public interface IGradeService
    {
        Task<IEnumerable<Grade>> GetGradesAsync();
        Task<Grade> GetGradeByIdAsync(int gradeId);
        Task<Grade> InsertGradeAsync(GradeRequest gradeReq);
        Task DeleteGradeAsync(int gradeId);
        Task UpdateGradeAsync(int gradeId, GradeRequest gradeReq);
    }
}