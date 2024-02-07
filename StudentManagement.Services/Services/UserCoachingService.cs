using AutoMapper;
using StudentManagement.Models.Entities;
using StudentManagement.Services.Interfaces;
using StudentManagment.Data.Repositories.Interfaces;
using StudentManagment.Data.Repositories.RepositoryInterfaces;
using StudentManagment.Data.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagement.Services.Services
{
    public class UserCoachingService : IUserCoachingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserCoachingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserCoaching>> GetUserCoachingsAsync()
        {
            return await _unitOfWork.UserCoachingRepository.GetUserCoachingsAsync();
        }

        public async Task<UserCoaching> GetUserCoachingByIdAsync(int userId, int coachingId)
        {
            return await _unitOfWork.UserCoachingRepository.GetUserCoachingByIdAsync(userId, coachingId);
        }

        public async Task InsertUserCoachingAsync(UserCoaching userCoaching)
        {
            await _unitOfWork.UserCoachingRepository.InsertUserCoachingAsync(userCoaching);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteUserCoachingAsync(int userId, int coachingId)
        {
            await _unitOfWork.UserCoachingRepository.DeleteUserCoachingAsync(userId, coachingId);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateUserCoachingAsync(UserCoaching userCoaching)
        {
            await _unitOfWork.UserCoachingRepository.UpdateUserCoachingAsync(userCoaching);
            await _unitOfWork.SaveAsync();
        }
    }

}
