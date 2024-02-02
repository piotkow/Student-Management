using StudentManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Services.Interfaces
{
    public interface ICourseTrainingService
    {
        Task<IEnumerable<CourseTraining>> GetCourseTrainingsAsync();
        Task<IEnumerable<CourseTraining>> GetCourseTrainingsByCourseIdAsync(int courseId);
        Task<CourseTraining> GetCourseTrainingByIdAsync(int courseId, int trainingId);
        Task InsertCourseTrainingAsync(CourseTraining courseTraining);
        Task DeleteCourseTrainingAsync(int courseId, int trainingId);
        Task UpdateCourseTrainingAsync(CourseTraining courseTraining);
    }
}
