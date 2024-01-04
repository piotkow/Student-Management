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
    public class UserCourseRepository : IUserCourseRepository, IDisposable
    {
        private StudentManagmentDbContext _context;

        public UserCourseRepository(StudentManagmentDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<UserCourse> GetUserCourses()
        {
            return _context.UserCourses.ToList();
        }

        public UserCourse GetUserCourseById(int id)
        {
            return _context.UserCourses.Find(id);
        }

        public void InsertUserCourse(UserCourse userCourse)
        {
            _context.UserCourses.Add(userCourse);
        }

        public void UpdateUserCourse(UserCourse userCourse)
        {
            _context.Entry(userCourse).State = EntityState.Modified;
        }

        public void DeleteUserCourse(int id)
        {
            UserCourse userCourse = _context.UserCourses.Find(id);
            _context.UserCourses.Remove(userCourse);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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
