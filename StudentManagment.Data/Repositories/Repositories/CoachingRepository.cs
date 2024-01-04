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
    public class CoachingRepository : ICoachingRepository, IDisposable
    {
        private StudentManagmentDbContext _context;

        public CoachingRepository(StudentManagmentDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<Coaching> GetCoachings()
        {
            return _context.Coachings.ToList();
        }

        public Coaching GetCoachingById(int id)
        {
            return _context.Coachings.Find(id);
        }

        public void InsertCoaching(Coaching coaching)
        {
            _context.Coachings.Add(coaching);
        }

        public void UpdateCoaching(Coaching coaching)
        {
            _context.Entry(coaching).State = EntityState.Modified;
        }

        public void DeleteCoaching(int id)
        {
            Coaching coaching = _context.Coachings.Find(id);
            _context.Coachings.Remove(coaching);
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
