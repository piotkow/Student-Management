using AutoMapper;
using StudentManagement.Models.Entities;
using StudentManagement.Services.Interfaces;
using StudentManagment.Data.Repositories.Interfaces;
using StudentManagment.Data.Repositories.RepositoryInterfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagement.Services.Services
{
    public class UserCourseService : IUserCourseService
    {
        private readonly IUserCourseRepository _userCourseRepository;
        private readonly IMapper _mapper;

        public UserCourseService(IUserCourseRepository userCourseRepository, IMapper mapper)
        {
            _userCourseRepository = userCourseRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserCourse>> GetUserCoursesAsync()
        {
            return await _userCourseRepository.GetUserCoursesAsync();
        }

        public async Task<UserCourse> GetUserCourseByIdAsync(int userId, int courseId)
        {
            return await _userCourseRepository.GetUserCourseByIdAsync(userId, courseId);
        }

        public async Task InsertUserCourseAsync(UserCourse userCourse)
        {
            await _userCourseRepository.InsertUserCourseAsync(userCourse);
        }

        public async Task DeleteUserCourseAsync(int userId, int courseId)
        {
            await _userCourseRepository.DeleteUserCourseAsync(userId, courseId);
        }

        public async Task UpdateUserCourseAsync(UserCourse userCourse)
        {
            await _userCourseRepository.UpdateUserCourseAsync(userCourse);
        }
    }
}

