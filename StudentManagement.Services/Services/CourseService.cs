using AutoMapper;
using StudentManagement.Models.Entities;
using StudentManagement.Services.DTOs.Course;
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

        public async Task<Course> InsertCourseAsync(CourseRequest courseReq)
        {
            await _unitOfWork.BeginTransactionAsync();
            var course = _mapper.Map<Course>(courseReq);
            await _unitOfWork.CourseRepository.InsertCourseAsync(course);
            await _unitOfWork.CommitAsync();
            return course;
        }

        public async Task DeleteCourseAsync(int courseId)
        {
            await _unitOfWork.CourseRepository.DeleteCourseAsync(courseId);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateCourseAsync(int courseId, CourseRequest courseReq)
        {
            await _unitOfWork.BeginTransactionAsync();
            var course = await _unitOfWork.CourseRepository.GetCourseByIdAsync(courseId);
            course.CourseName = courseReq.CourseName;
            course.Description = courseReq.Description;
            await _unitOfWork.CourseRepository.UpdateCourseAsync(course);
            await _unitOfWork.CommitAsync();
        }
    }

}
