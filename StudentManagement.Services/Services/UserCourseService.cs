using AutoMapper;
using StudentManagement.Models.Entities;
using StudentManagement.Services.Interfaces;
using StudentManagment.Data.Repositories.Interfaces;
using StudentManagment.Data.Repositories.RepositoryInterfaces;
using StudentManagment.Data.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagement.Services.Services
{
    public class UserCourseService : IUserCourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserCourseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserCourse>> GetUserCoursesAsync()
        {
            return await _unitOfWork.UserCourseRepository.GetUserCoursesAsync();
        }

        public async Task<IEnumerable<UserCourse>> GetUserCoursesByUserIdAsync(int userId)
        {
            return await _unitOfWork.UserCourseRepository.GetUserCoursesByUserIdAsync(userId);
        }

        public async Task<UserCourse> GetUserCourseByIdAsync(int userId, int courseId)
        {
            return await _unitOfWork.UserCourseRepository.GetUserCourseByIdAsync(userId, courseId);
        }

        public async Task InsertUserCourseAsync(UserCourse userCourse)
        {
            await _unitOfWork.UserCourseRepository.InsertUserCourseAsync(userCourse);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteUserCourseAsync(int userId, int courseId)
        {
            await _unitOfWork.UserCourseRepository.DeleteUserCourseAsync(userId, courseId);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateUserCourseAsync(UserCourse userCourse)
        {
            await _unitOfWork.UserCourseRepository.UpdateUserCourseAsync(userCourse);
            await _unitOfWork.SaveAsync();
        }
    }
}

