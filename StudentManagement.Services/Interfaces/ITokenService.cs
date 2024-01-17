using StudentManagement.Models.Entities;
using StudentManagement.Services.DTOs.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagement.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
        bool ValidateToken(string token);
    }

}
