using StudentManagement.Models.Entities;
using StudentManagement.Services.DTOs.Course;
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
        Task<Course> InsertCourseAsync(CourseRequest course);
        Task DeleteCourseAsync(int courseId);
        Task UpdateCourseAsync(int courseId, CourseRequest course);
    }
}
