using StudentManagement.Models.Entities;
using StudentManagement.Services.DTOs.Coaching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Services.Interfaces
{
    public interface ICoachingService
    {
        Task<IEnumerable<Coaching>> GetCoachesAsync();
        Task<Coaching> GetCoachByIdAsync(int coachingId);
        Task<Coaching> InsertCoachAsync(CoachingRequest coachingReq);
        Task DeleteCoachAsync(int coachingId);
        Task UpdateCoachAsync(int coachingId, CoachingRequest coachingReq);
    }
}
