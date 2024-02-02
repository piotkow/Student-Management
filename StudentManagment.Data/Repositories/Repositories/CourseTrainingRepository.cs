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
    public class CourseTrainingRepository : ICourseTrainingRepository
    {
        private StudentManagmentDbContext _context;

        public CourseTrainingRepository(StudentManagmentDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<CourseTraining>> GetCourseTrainingsAsync()
        {
            return await _context.CourseTrainings.ToListAsync();
        }

        public async Task<IEnumerable<CourseTraining>> GetCourseTrainingsByCourseIdAsync(int courseId)
        {
             return await _context.CourseTrainings.Join(
                _context.Trainings,
                ct => ct.TrainingID,
                t => t.TrainingID,
                (uc, t) => new CourseTraining
                {
                    CourseID = uc.CourseID,
                    Course = null,
                    TrainingID = t.TrainingID,
                    Training = new Training
                    {
                        TrainingID = t.TrainingID,
                        Location = t.Location,
                        StartDate = t.StartDate,
                        EndDate = t.EndDate,
                        Topic = t.Topic,
                        Attendances = null,
                        CourseTrainings = null,
                        Grades = null
                    }
                }
            )
            .Where(ct => ct.CourseID== courseId)
            .ToListAsync();
        }

        public async Task<CourseTraining> GetCourseTrainingByIdAsync(int courseId, int trainingId)
        {
            return await _context.CourseTrainings
                .FirstOrDefaultAsync(ct => ct.CourseID == courseId && ct.TrainingID == trainingId);
        }

        public async Task InsertCourseTrainingAsync(CourseTraining courseTraining)
        {
            await _context.CourseTrainings.AddAsync(courseTraining);
        }

        public async Task UpdateCourseTrainingAsync(CourseTraining courseTraining)
        {
            _context.Entry(courseTraining).State = EntityState.Modified;
        }

        public async Task DeleteCourseTrainingAsync(int courseId, int trainingId)
        {
            CourseTraining courseTraining = await _context.CourseTrainings
                .FirstOrDefaultAsync(ct => ct.CourseID == courseId && ct.TrainingID == trainingId);
            _context.CourseTrainings.Remove(courseTraining);
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
