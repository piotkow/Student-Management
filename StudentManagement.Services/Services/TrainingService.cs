using AutoMapper;
using StudentManagement.Models.Entities;
using StudentManagement.Services.DTOs.Training;
using StudentManagement.Services.Interfaces;
using StudentManagment.Data.Repositories.Interfaces;
using StudentManagment.Data.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagement.Services.Services
{
    public class TrainingService : ITrainingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TrainingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Training>> GetTrainingsAsync()
        {
            return await _unitOfWork.TrainingRepository.GetTrainingsAsync();
        }

        public async Task<Training> GetTrainingByIdAsync(int trainingId)
        {
            return await _unitOfWork.TrainingRepository.GetTrainingByIdAsync(trainingId);
        }

        public async Task<Training> InsertTrainingAsync(TrainingRequest trainingReq)
        {
            await _unitOfWork.BeginTransactionAsync();
            var training = _mapper.Map<Training>(trainingReq);
            await _unitOfWork.TrainingRepository.InsertTrainingAsync(training);
            await _unitOfWork.CommitAsync();
            return training;
        }

        public async Task DeleteTrainingAsync(int trainingId)
        {
            await _unitOfWork.TrainingRepository.DeleteTrainingAsync(trainingId);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateTrainingAsync(int trainingId, TrainingRequest trainingReq)
        {
            await _unitOfWork.BeginTransactionAsync();
            var training = await _unitOfWork.TrainingRepository.GetTrainingByIdAsync(trainingId);
            training.Location = trainingReq.Location;
            training.Topic = trainingReq.Topic;
            training.StartDate = trainingReq.StartDate;
            training.EndDate = trainingReq.EndDate;
            await _unitOfWork.TrainingRepository.UpdateTrainingAsync(training);
            await _unitOfWork.CommitAsync();
        }

    }
}
