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
        Task<IEnumerable<Training>> GetTrainingsAsync();
        Task<Training> GetTrainingByIdAsync(int id);
        Task InsertTrainingAsync(Training training);
        Task UpdateTrainingAsync(Training training);
        Task DeleteTrainingAsync(int id);
        Task SaveAsync();
    }
}
