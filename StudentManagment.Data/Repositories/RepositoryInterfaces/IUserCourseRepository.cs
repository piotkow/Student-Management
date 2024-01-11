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
        Task<IEnumerable<UserCourse>> GetUserCoursesAsync();
        Task<UserCourse> GetUserCourseByIdAsync(int userId, int courseId);
        Task InsertUserCourseAsync(UserCourse userCourse);
        Task UpdateUserCourseAsync(UserCourse userCourse);
        Task DeleteUserCourseAsync(int userId, int courseId);
        Task SaveAsync();
    }
}
