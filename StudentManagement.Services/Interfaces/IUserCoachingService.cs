using StudentManagement.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagement.Services.Interfaces
{
    public interface IUserCoachingService
    {
        Task<IEnumerable<UserCoaching>> GetUserCoachingsAsync();
        Task<UserCoaching> GetUserCoachingByIdAsync(int userId, int coachingId);
        Task InsertUserCoachingAsync(UserCoaching userCoaching);
        Task DeleteUserCoachingAsync(int userId, int coachingId);
        Task UpdateUserCoachingAsync(UserCoaching userCoaching);
    }
}
