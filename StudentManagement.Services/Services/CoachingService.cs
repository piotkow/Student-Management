using AutoMapper;
using StudentManagement.Models.Entities;
using StudentManagment.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Services.Services
{
    public class CoachingService
    {
        private readonly ICoachingRepository _coachingRepository;
        private readonly IMapper _mapper;

        public CoachingService(ICoachingRepository coachingRepository, IMapper mapper)
        {
            _coachingRepository = coachingRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Coaching>> GetCoachesAsync()
        {
            return await _coachingRepository.GetCoachingsAsync();
        }

        public async Task<Coaching> GetCoachByIdAsync(int coachingId)
        {
            return await _coachingRepository.GetCoachingByIdAsync(coachingId);
        }

        public async Task InsertCoachAsync(Coaching coaching)
        {

            await _coachingRepository.InsertCoachingAsync(coaching);
        }

        public async Task DeleteCoachAsync(int coachingId)
        {
            await _coachingRepository.DeleteCoachingAsync(coachingId);
        }

        public async Task UpdateCoachAsync(Coaching coaching)
        {

            await _coachingRepository.UpdateCoachingAsync(coaching);
        }
    }
}
