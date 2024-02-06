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
    public class AttendanceRepository : IAttendanceRepository
    {
        private StudentManagmentDbContext _context;

        public AttendanceRepository(StudentManagmentDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Attendance>> GetAttendancesAsync()
        {
            return await _context.Attendances.Include(a=>a.User).ToListAsync();
        }

        public async Task<Attendance> GetAttendanceByIdAsync(int id)
        {
            return await _context.Attendances.FindAsync(id);
        }

        public async Task InsertAttendanceAsync(Attendance attendance)
        {
            await _context.Attendances.AddAsync(attendance);
        }

        public async Task UpdateAttendanceAsync(Attendance attendance)
        {
            _context.Entry(attendance).State = EntityState.Modified;
        }

        public async Task DeleteAttendanceAsync(int id)
        {
            Attendance attendance = await _context.Attendances.FindAsync(id);
            _context.Attendances.Remove(attendance);
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
