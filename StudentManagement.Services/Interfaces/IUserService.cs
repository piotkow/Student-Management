using StudentManagement.Models.Entities;
using StudentManagement.Services.DTOs.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagement.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int userId);
        Task InsertUserAsync(User user);
        Task DeleteUserAsync(int userId);
        Task UpdateUserAsync(User user);
        Task<User> AuthenticateUser(UserLoginRequest user);
    }
}
