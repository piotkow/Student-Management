using StudentManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagment.Data.Repositories.Interfaces
{
    public interface ICourseRepository : IDisposable
    {
        Task<IEnumerable<Course>> GetCoursesAsync();
        Task<Course> GetCourseByIdAsync(int id);
        Task InsertCourseAsync(Course course);
        Task UpdateCourseAsync(Course course);
        Task DeleteCourseAsync(int id);
        Task SaveAsync();
    }
}
