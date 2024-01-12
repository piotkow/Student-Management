using AutoMapper;
using StudentManagement.Models.Entities;
using StudentManagement.Services.Interfaces;
using StudentManagment.Data.Repositories.Interfaces;
using StudentManagment.Data.Repositories.RepositoryInterfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagement.Services.Services
{
    public class UserCoachingService : IUserCoachingService
    {
        private readonly IUserCoachingRepository _userCoachingRepository;
        private readonly IMapper _mapper;

        public UserCoachingService(IUserCoachingRepository userCoachingRepository, IMapper mapper)
        {
            _userCoachingRepository = userCoachingRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserCoaching>> GetUserCoachingsAsync()
        {
            return await _userCoachingRepository.GetUserCoachingsAsync();
        }

        public async Task<UserCoaching> GetUserCoachingByIdAsync(int userId, int coachingId)
        {
            return await _userCoachingRepository.GetUserCoachingByIdAsync(userId, coachingId);
        }

        public async Task InsertUserCoachingAsync(UserCoaching userCoaching)
        {
            await _userCoachingRepository.InsertUserCoachingAsync(userCoaching);
        }

        public async Task DeleteUserCoachingAsync(int userId, int coachingId)
        {
            await _userCoachingRepository.DeleteUserCoachingAsync(userId, coachingId);
        }

        public async Task UpdateUserCoachingAsync(UserCoaching userCoaching)
        {
            await _userCoachingRepository.UpdateUserCoachingAsync(userCoaching);
        }
    }
}
