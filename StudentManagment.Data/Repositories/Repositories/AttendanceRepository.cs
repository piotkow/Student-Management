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
    public class AttendanceRepository : IAttendanceRepository, IDisposable
    {
        private StudentManagmentDbContext _context;

        public AttendanceRepository(StudentManagmentDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<Attendance> GetAttendances()
        {
            return _context.Attendances.ToList();
        }

        public Attendance GetAttendanceById(int id)
        {
            return _context.Attendances.Find(id);
        }

        public void InsertAttendance(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
        }

        public void UpdateAttendance(Attendance attendance)
        {
            _context.Entry(attendance).State = EntityState.Modified;
        }

        public void DeleteAttendance(int id)
        {
            Attendance attendance = _context.Attendances.Find(id);
            _context.Attendances.Remove(attendance);
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
