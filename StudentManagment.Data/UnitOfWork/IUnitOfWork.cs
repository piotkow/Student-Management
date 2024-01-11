using StudentManagment.Data.Repositories.Interfaces;
using StudentManagment.Data.Repositories.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagment.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAttendanceRepository AttendanceRepository { get; }
        ICoachingRepository CoachingRepository { get; }
        ICourseRepository CourseRepository { get; }
        ICourseTrainingRepository CourseTrainingRepository { get; }
        IGradeRepository GradeRepository { get; }
        ITrainingRepository TrainingRepository { get; }
        IUserRepository UserRepository { get; }
        IUserCoachingRepository UserCoachingRepository { get; }
        IUserCourseRepository UserCourseRepository { get; }

        Task SaveAsync();
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }

}
