using StudentManagement.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagement.Services.Interfaces
{
    public interface ITrainingService  
    {
        Task<IEnumerable<Training>> GetTrainingsAsync();  
        Task<Training> GetTrainingByIdAsync(int trainingId); 
        Task InsertTrainingAsync(Training training);  
        Task DeleteTrainingAsync(int trainingId);  
        Task UpdateTrainingAsync(Training training);  
    }
}
