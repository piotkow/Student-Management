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
    public class CoachingRepository : ICoachingRepository
    {
        private StudentManagmentDbContext _context;

        public CoachingRepository(StudentManagmentDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Coaching>> GetCoachingsAsync()
        {
            return await _context.Coachings.ToListAsync();
        }

        public async Task<Coaching> GetCoachingByIdAsync(int id)
        {
            return await _context.Coachings.FindAsync(id);
        }

        public async Task InsertCoachingAsync(Coaching coaching)
        {
            await _context.Coachings.AddAsync(coaching);
        }

        public async Task UpdateCoachingAsync(Coaching coaching)
        {
            _context.Entry(coaching).State = EntityState.Modified;
        }

        public async Task DeleteCoachingAsync(int id)
        {
            Coaching coaching = await _context.Coachings.FindAsync(id);
            _context.Coachings.Remove(coaching);
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
