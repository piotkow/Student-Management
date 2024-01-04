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
    public class TrainingRepository : ITrainingRepository, IDisposable
    {
        private StudentManagmentDbContext _context;

        public TrainingRepository(StudentManagmentDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<Training> GetTrainings()
        {
            return _context.Trainings.ToList();
        }

        public Training GetTrainingById(int id)
        {
            return _context.Trainings.Find(id);
        }

        public void InsertTraining(Training training)
        {
            _context.Trainings.Add(training);
        }

        public void UpdateTraining(Training training)
        {
            _context.Entry(training).State = EntityState.Modified;
        }

        public void DeleteTraining(int id)
        {
            Training training = _context.Trainings.Find(id);
            _context.Trainings.Remove(training);
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
