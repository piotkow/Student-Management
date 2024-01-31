using StudentManagement.Models.Entities;
using StudentManagement.Services.DTOs.Training;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagement.Services.Interfaces
{
    public interface ITrainingService  
    {
        Task<IEnumerable<Training>> GetTrainingsAsync();  
        Task<Training> GetTrainingByIdAsync(int trainingId); 
        Task<Training> InsertTrainingAsync(TrainingRequest trainingReq);  
        Task DeleteTrainingAsync(int trainingId);  
        Task UpdateTrainingAsync(int trainingId, TrainingRequest trainingReq);  
    }
}
