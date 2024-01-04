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
        IEnumerable<Course> GetCourses();
        Course GetCourseById(int id);
        void InsertCourse(Course course);
        void DeleteCourse(int id);
        void UpdateCourse(Course course);
        void Save();
    }
}
