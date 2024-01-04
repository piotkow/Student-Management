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
        IEnumerable<Grade> GetGrades();
        Grade GetGradeById(int id);
        void InsertGrade(Grade grade);
        void DeleteGrade(int id);
        void UpdateGrade(Grade grade);
        void Save();
    }
}
