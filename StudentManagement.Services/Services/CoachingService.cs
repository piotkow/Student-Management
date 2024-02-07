using AutoMapper;
using StudentManagement.Models.Entities;
using StudentManagement.Services.DTOs.Coaching;
using StudentManagement.Services.Interfaces;
using StudentManagment.Data.Repositories.Interfaces;
using StudentManagment.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Services.Services
{
    public class CoachingService : ICoachingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CoachingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Coaching>> GetCoachesAsync()
        {
            return await _unitOfWork.CoachingRepository.GetCoachingsAsync();
        }

        public async Task<Coaching> GetCoachByIdAsync(int coachingId)
        {
            return await _unitOfWork.CoachingRepository.GetCoachingByIdAsync(coachingId);
        }

        public async Task<Coaching> InsertCoachAsync(CoachingRequest coachingReq)
        {
            await _unitOfWork.BeginTransactionAsync();
            var coaching = _mapper.Map<Coaching>(coachingReq);
            await _unitOfWork.CoachingRepository.InsertCoachingAsync(coaching);
            await _unitOfWork.CommitAsync();
            return coaching;
        }

        public async Task DeleteCoachAsync(int coachingId)
        {
            await _unitOfWork.CoachingRepository.DeleteCoachingAsync(coachingId);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateCoachAsync(int coachingId, CoachingRequest coachingReq)
        {
            await _unitOfWork.BeginTransactionAsync();
            var coaching = await _unitOfWork.CoachingRepository.GetCoachingByIdAsync(coachingId);
            coaching.Location = coachingReq.Location;
            coaching.StartDate = coachingReq.StartDate;
            coaching.EndDate = coachingReq.EndDate;
            coaching.Topic = coachingReq.Topic;
            coaching.Feedback = coachingReq.Feedback;
            await _unitOfWork.CoachingRepository.UpdateCoachingAsync(coaching);
            await _unitOfWork.CommitAsync();
        }
    }

}
