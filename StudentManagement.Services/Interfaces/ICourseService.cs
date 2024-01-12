using StudentManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Services.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetCoursesAsync();
        Task<Course> GetCourseByIdAsync(int courseId);
        Task InsertCourseAsync(Course course);
        Task DeleteCourseAsync(int courseId);
        Task UpdateCourseAsync(Course course);
    }
}
