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
    public class TrainingRepository : ITrainingRepository
    {
        private StudentManagmentDbContext _context;

        public TrainingRepository(StudentManagmentDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Training>> GetTrainingsAsync()
        {
            return await _context.Trainings.ToListAsync();
        }

        public async Task<Training> GetTrainingByIdAsync(int id)
        {
            return await _context.Trainings.FindAsync(id);
        }

        public async Task InsertTrainingAsync(Training training)
        {
            await _context.Trainings.AddAsync(training);
        }

        public async Task UpdateTrainingAsync(Training training)
        {
            _context.Entry(training).State = EntityState.Modified;
        }

        public async Task DeleteTrainingAsync(int id)
        {
            Training training = await _context.Trainings.FindAsync(id);
            _context.Trainings.Remove(training);
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
