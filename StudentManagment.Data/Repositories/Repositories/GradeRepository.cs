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
    public class GradeRepository : IGradeRepository, IDisposable
    {
        private StudentManagmentDbContext _context;

        public GradeRepository(StudentManagmentDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<Grade> GetGrades()
        {
            return _context.Grades.ToList();
        }

        public Grade GetGradeById(int id)
        {
            return _context.Grades.Find(id);
        }

        public void InsertGrade(Grade grade)
        {
            _context.Grades.Add(grade);
        }

        public void UpdateGrade(Grade grade)
        {
            _context.Entry(grade).State = EntityState.Modified;
        }

        public void DeleteGrade(int id)
        {
            Grade grade = _context.Grades.Find(id);
            _context.Grades.Remove(grade);
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
