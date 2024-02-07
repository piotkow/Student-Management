using StudentManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagment.Data.Repositories.RepositoryInterfaces
{
    public interface IUserCoachingRepository : IDisposable
    {
        Task<IEnumerable<UserCoaching>> GetUserCoachingsAsync();
        Task<UserCoaching> GetUserCoachingByIdAsync(int userId, int coachingId);
        Task InsertUserCoachingAsync(UserCoaching userCoaching);
        Task UpdateUserCoachingAsync(UserCoaching userCoaching);
        Task DeleteUserCoachingAsync(int userId, int coachingId);
        Task SaveAsync();
    }
}
