﻿using StudentManagement.Models.Entities;
using StudentManagement.Services.DTOs.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagement.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int userId);
        Task<User> InsertUserAsync(UserRequest userReq);
        Task DeleteUserAsync(int userId);
        Task UpdateUserAsync(int userId, UserRequest userReq);
        Task<User> AuthenticateUser(UserLoginRequest user);
    }
}
