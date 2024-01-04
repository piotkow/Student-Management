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
    public class InstructorRepository : IInstructorRepository, IDisposable
    {
        private StudentManagmentDbContext _context;

        public InstructorRepository(StudentManagmentDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<Instructor> GetInstructors()
        {
            return _context.Instructors.ToList();
        }

        public Instructor GetInstructorById(int id)
        {
            return _context.Instructors.Find(id);
        }

        public void InsertInstructor(Instructor instructor)
        {
            _context.Instructors.Add(instructor);
        }

        public void UpdateInstructor(Instructor instructor)
        {
            _context.Entry(instructor).State = EntityState.Modified;
        }

        public void DeleteInstructor(int id)
        {
            Instructor instructor = _context.Instructors.Find(id);
            _context.Instructors.Remove(instructor);
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
