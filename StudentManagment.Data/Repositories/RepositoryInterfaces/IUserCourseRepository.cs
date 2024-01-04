using StudentManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagment.Data.Repositories.Interfaces
{
    public interface IUserCourseRepository : IDisposable
    {
        IEnumerable<UserCourse> GetUserCourses();
        UserCourse GetUserCourseById(int id);
        void InsertUserCourse(UserCourse userCourse);
        void DeleteUserCourse(int id);
        void UpdateUserCourse(UserCourse userCourse);
        void Save();
    }
}
