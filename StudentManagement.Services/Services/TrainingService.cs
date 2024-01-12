using AutoMapper;
using StudentManagement.Models.Entities;
using StudentManagement.Services.Interfaces;
using StudentManagment.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagement.Services.Services
{
    public class TrainingService : ITrainingService
    {
        private readonly ITrainingRepository _trainingRepository;
        private readonly IMapper _mapper;

        public TrainingService(ITrainingRepository trainingRepository, IMapper mapper)
        {
            _trainingRepository = trainingRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Training>> GetTrainingsAsync()
        {
            return await _trainingRepository.GetTrainingsAsync();
        }

        public async Task<Training> GetTrainingByIdAsync(int trainingId)
        {
            return await _trainingRepository.GetTrainingByIdAsync(trainingId);
        }

        public async Task InsertTrainingAsync(Training training)
        {
            await _trainingRepository.InsertTrainingAsync(training);
        }

        public async Task DeleteTrainingAsync(int trainingId)
        {
            await _trainingRepository.DeleteTrainingAsync(trainingId);
        }

        public async Task UpdateTrainingAsync(Training training)
        {
            await _trainingRepository.UpdateTrainingAsync(training);
        }
    }
}
