using StudentManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagement.Services.Interfaces
{
    public interface IGradeService
    {
        Task<IEnumerable<Grade>> GetGradesAsync();
        Task<Grade> GetGradeByIdAsync(int gradeId);
        Task InsertGradeAsync(Grade grade);
        Task DeleteGradeAsync(int gradeId);
        Task UpdateGradeAsync(Grade grade);
    }
}