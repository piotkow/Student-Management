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
        IEnumerable<CourseTraining> GetCourseTrainings();
        CourseTraining GetCourseTrainingById(int id);
        void InsertCourseTraining(CourseTraining courseTraining);
        void DeleteCourseTraining(int id);
        void UpdateCourseTraining(CourseTraining courseTraining);
        void Save();
    }
}
