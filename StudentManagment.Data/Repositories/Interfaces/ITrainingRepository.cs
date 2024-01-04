using StudentManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagment.Data.Repositories.Interfaces
{
    public interface ITrainingRepository : IDisposable
    {
        IEnumerable<Training> GetTrainings();
        Training GetTrainingById(int id);
        void InsertTraining(Training training);
        void DeleteTraining(int id);
        void UpdateTraining(Training training);
        void Save();
    }
}
