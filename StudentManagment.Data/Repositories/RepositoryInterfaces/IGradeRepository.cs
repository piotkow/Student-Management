using StudentManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagment.Data.Repositories.Interfaces
{
    public interface IGradeRepository : IDisposable
    {
        Task<IEnumerable<Grade>> GetGradesAsync();
        Task<Grade> GetGradeByIdAsync(int id);
        Task InsertGradeAsync(Grade grade);
        Task UpdateGradeAsync(Grade grade);
        Task DeleteGradeAsync(int id);
        Task SaveAsync();
    }
}
