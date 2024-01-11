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
    public class GradeRepository : IGradeRepository
    {
        private StudentManagmentDbContext _context;

        public GradeRepository(StudentManagmentDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Grade>> GetGradesAsync()
        {
            return await _context.Grades.ToListAsync();
        }

        public async Task<Grade> GetGradeByIdAsync(int id)
        {
            return await _context.Grades.FindAsync(id);
        }

        public async Task InsertGradeAsync(Grade grade)
        {
            await _context.Grades.AddAsync(grade);
        }

        public async Task UpdateGradeAsync(Grade grade)
        {
            _context.Entry(grade).State = EntityState.Modified;
        }

        public async Task DeleteGradeAsync(int id)
        {
            Grade grade = await _context.Grades.FindAsync(id);
            _context.Grades.Remove(grade);
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
