using StudentManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagment.Data.Repositories.Interfaces
{
    public interface ICourseTrainingRepository : IDisposable
    {
        Task<IEnumerable<CourseTraining>> GetCourseTrainingsAsync();
        Task<CourseTraining> GetCourseTrainingByIdAsync(int courseId, int trainingId);
        Task InsertCourseTrainingAsync(CourseTraining courseTraining);
        Task UpdateCourseTrainingAsync(CourseTraining courseTraining);
        Task DeleteCourseTrainingAsync(int courseId, int trainingId);
        Task SaveAsync();
    }
}
