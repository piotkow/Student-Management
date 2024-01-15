using AutoMapper;
using StudentManagement.Models.Entities;
using StudentManagement.Services.Interfaces;
using StudentManagment.Data.Repositories.Interfaces;
using StudentManagment.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Services.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CourseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Course>> GetCoursesAsync()
        {
            return await _unitOfWork.CourseRepository.GetCoursesAsync();
        }

        public async Task<Course> GetCourseByIdAsync(int courseId)
        {
            return await _unitOfWork.CourseRepository.GetCourseByIdAsync(courseId);
        }

        public async Task InsertCourseAsync(Course course)
        {
            await _unitOfWork.CourseRepository.InsertCourseAsync(course);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteCourseAsync(int courseId)
        {
            await _unitOfWork.CourseRepository.DeleteCourseAsync(courseId);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateCourseAsync(Course course)
        {
            await _unitOfWork.CourseRepository.UpdateCourseAsync(course);
            await _unitOfWork.SaveAsync();
        }
    }

}
