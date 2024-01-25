using AutoMapper;
using StudentManagement.Models.Entities;
using StudentManagement.Services.DTOs.User;
using StudentManagement.Services.Interfaces;
using StudentManagment.Data.Repositories.Interfaces;
using StudentManagment.Data.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagement.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _unitOfWork.UserRepository.GetUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _unitOfWork.UserRepository.GetUserByIdAsync(userId);
        }

        public async Task<User> InsertUserAsync(UserRequest userReq)
        {
            await _unitOfWork.BeginTransactionAsync();
            var user = _mapper.Map<User>(userReq);
            //user.UserID=GenerateNewUserId();
            await _unitOfWork.UserRepository.InsertUserAsync(user);
            await _unitOfWork.CommitAsync();
            return user;
        }

        public async Task DeleteUserAsync(int userId)
        {
            await _unitOfWork.UserRepository.DeleteUserAsync(userId);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateUserAsync(int userId, UserRequest userReq)
        {
            await _unitOfWork.BeginTransactionAsync();
            var user = await _unitOfWork.UserRepository.GetUserByIdAsync(userId);
            user.Username = userReq.Username;
            user.Password = userReq.Password;
            user.Role = userReq.Role;
            user.Email = userReq.Email;
            user.FirstName = userReq.FirstName;
            user.LastName = userReq.LastName;
            user.DateOfBirth= userReq.DateOfBirth;
            user.Avatar=userReq.Avatar;
            user.Phone = userReq.Phone;
            await _unitOfWork.UserRepository.UpdateUserAsync(user);
            await _unitOfWork.CommitAsync();
        }

        public async Task<User> AuthenticateUser(UserLoginRequest user)
        {
            try
            {
                if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
                {
                    return null;
                }

                var existingUser = await _unitOfWork.UserRepository.GetUserByNameAsync(user.Username);

                if (existingUser != null && user.Password == existingUser.Password)
                {
                    return existingUser;
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        //private int GenerateNewUserId()
        //{
        //    return _unitOfWork.UserRepository.GetUsersAsync().Result.Max(x => x.UserID)+1;
        //}

    }
}

