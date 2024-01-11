using StudentManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagment.Data.Repositories.Interfaces
{
    public interface ICoachingRepository : IDisposable
    {
        Task<IEnumerable<Coaching>> GetCoachingsAsync();
        Task<Coaching> GetCoachingByIdAsync(int id);
        Task InsertCoachingAsync(Coaching coaching);
        Task UpdateCoachingAsync(Coaching coaching);
        Task DeleteCoachingAsync(int id);
        Task SaveAsync();
    }
}
