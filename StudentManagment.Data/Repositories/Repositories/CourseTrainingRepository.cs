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
    public class CourseTrainingRepository : ICourseTrainingRepository, IDisposable
    {
        private StudentManagmentDbContext _context;

        public CourseTrainingRepository(StudentManagmentDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<CourseTraining> GetCourseTrainings()
        {
            return _context.CourseTrainings.ToList();
        }

        public CourseTraining GetCourseTrainingById(int id)
        {
            return _context.CourseTrainings.Find(id);
        }

        public void InsertCourseTraining(CourseTraining courseTraining)
        {
            _context.CourseTrainings.Add(courseTraining);
        }

        public void UpdateCourseTraining(CourseTraining courseTraining)
        {
            _context.Entry(courseTraining).State = EntityState.Modified;
        }

        public void DeleteCourseTraining(int id)
        {
            CourseTraining courseTraining = _context.CourseTrainings.Find(id);
            _context.CourseTrainings.Remove(courseTraining);
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
