using StudentManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagment.Data.Repositories.Interfaces
{
    public interface IUserRepository : IDisposable
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByNameAsync(string name);
        Task InsertUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task SaveAsync();
    }
}
