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
    public class CourseRepository : ICourseRepository
    {
        private StudentManagmentDbContext _context;

        public CourseRepository(StudentManagmentDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Course>> GetCoursesAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            return await _context.Courses.FindAsync(id);
        }

        public async Task InsertCourseAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
        }

        public async Task UpdateCourseAsync(Course course)
        {
            _context.Entry(course).State = EntityState.Modified;
        }

        public async Task DeleteCourseAsync(int id)
        {
            Course course = await _context.Courses.FindAsync(id);
            _context.Courses.Remove(course);
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
