using StudentManagement.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagement.Services.Interfaces
{
    public interface IUserCourseService
    {
        Task<IEnumerable<UserCourse>> GetUserCoursesAsync();
        Task<IEnumerable<UserCourse>> GetUserCoursesByUserIdAsync(int userId);
        Task<UserCourse> GetUserCourseByIdAsync(int userId, int courseId);
        Task InsertUserCourseAsync(UserCourse userCourse);
        Task DeleteUserCourseAsync(int userId, int courseId);
        Task UpdateUserCourseAsync(UserCourse userCourse);
    }
}
