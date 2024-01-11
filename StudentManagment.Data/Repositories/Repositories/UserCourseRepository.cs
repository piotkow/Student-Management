using Microsoft.EntityFrameworkCore;
using StudentManagement.Models.Entities;
using StudentManagment.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagment.Data.Repositories.Repositories
{
    public class UserCourseRepository : IUserCourseRepository
    {
        private StudentManagmentDbContext _context;

        public UserCourseRepository(StudentManagmentDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<UserCourse>> GetUserCoursesAsync()
        {
            return await _context.UserCourses.ToListAsync();
        }

        public async Task<UserCourse> GetUserCourseByIdAsync(int userId, int courseId)
        {
            return await _context.UserCourses
                .FirstOrDefaultAsync(uc => uc.UserID == userId && uc.CourseID == courseId);
        }

        public async Task InsertUserCourseAsync(UserCourse userCourse)
        {
            await _context.UserCourses.AddAsync(userCourse);
        }

        public async Task UpdateUserCourseAsync(UserCourse userCourse)
        {
            _context.Entry(userCourse).State = EntityState.Modified;
        }

        public async Task DeleteUserCourseAsync(int userId, int courseId)
        {
            UserCourse userCourse = await _context.UserCourses
                .FirstOrDefaultAsync(uc => uc.UserID == userId && uc.CourseID == courseId);
            _context.UserCourses.Remove(userCourse);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual async void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    await _context.DisposeAsync();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
