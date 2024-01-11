using Microsoft.EntityFrameworkCore;
using StudentManagement.Models.Entities;
using StudentManagment.Data.Repositories.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagment.Data.Repositories.Repositories
{
    public class UserCoachingRepository : IUserCoachingRepository
    {
        private StudentManagmentDbContext _context;

        public UserCoachingRepository(StudentManagmentDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<UserCoaching>> GetUserCoachingsAsync()
        {
            return await _context.UserCoachings.ToListAsync();
        }

        public async Task<UserCoaching> GetUserCoachingByIdAsync(int userId, int coachingId)
        {
            return await _context.UserCoachings
                .FirstOrDefaultAsync(uc => uc.UserID == userId && uc.CoachingID == coachingId);
        }

        public async Task InsertUserCoachingAsync(UserCoaching userCoaching)
        {
            await _context.UserCoachings.AddAsync(userCoaching);
        }

        public async Task UpdateUserCoachingAsync(UserCoaching userCoaching)
        {
            _context.Entry(userCoaching).State = EntityState.Modified;
        }

        public async Task DeleteUserCoachingAsync(int userId, int coachingId)
        {
            UserCoaching userCoaching = await _context.UserCoachings
                .FirstOrDefaultAsync(uc => uc.UserID== userId && uc.CoachingID == coachingId);
            _context.UserCoachings.Remove(userCoaching);
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
