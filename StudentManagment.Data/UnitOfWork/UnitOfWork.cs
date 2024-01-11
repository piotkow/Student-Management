using Microsoft.EntityFrameworkCore.Storage;
using StudentManagment.Data.Repositories.Interfaces;
using StudentManagment.Data.Repositories.Repositories;
using StudentManagment.Data.Repositories.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagment.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StudentManagmentDbContext context;
        private IDbContextTransaction _transaction;

        public UnitOfWork(StudentManagmentDbContext dbContext)
        {
            context = dbContext;
            AttendanceRepository = new AttendanceRepository(context);
            CoachingRepository = new CoachingRepository(context);
            CourseTrainingRepository = new CourseTrainingRepository(context);
            GradeRepository = new GradeRepository(context);
            TrainingRepository = new TrainingRepository(context);
            UserRepository = new UserRepository(context);
            UserCoachingRepository = new UserCoachingRepository(context);
            UserCourseRepository = new UserCourseRepository(context);
        }

        public IAttendanceRepository AttendanceRepository { get; private set; }
        public ICoachingRepository CoachingRepository { get; private set; }
        public ICourseRepository CourseRepository { get; private set; }
        public ICourseTrainingRepository CourseTrainingRepository { get; private set; }
        public IGradeRepository GradeRepository { get; private set; }
        public ITrainingRepository TrainingRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }
        public IUserCoachingRepository UserCoachingRepository { get; private set; }
        public IUserCourseRepository UserCourseRepository { get; private set; }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            try
            {
                await context.SaveChangesAsync();
                await _transaction.CommitAsync();
            }
            catch
            {
                await RollbackAsync();
                throw;
            }
            finally
            {
                await _transaction.DisposeAsync();
            }
        }

        public async Task RollbackAsync()
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
        }
    }

}
