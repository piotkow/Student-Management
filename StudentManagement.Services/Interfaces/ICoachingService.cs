using StudentManagement.Models.Entities;
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
        Task InsertCoachAsync(Coaching coaching);
        Task DeleteCoachAsync(int coachingId);
        Task UpdateCoachAsync(Coaching coaching);
    }
}
