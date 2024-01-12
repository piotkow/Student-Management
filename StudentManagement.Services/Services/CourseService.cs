using AutoMapper;
using StudentManagement.Models.Entities;
using StudentManagment.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Services.Services
{
    public class CourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Course>> GetCoursesAsync()
        {
            return await _courseRepository.GetCoursesAsync();
        }

        public async Task<Course> GetCourseByIdAsync(int courseId)
        {
            return await _courseRepository.GetCourseByIdAsync(courseId);
        }

        public async Task InsertCourseAsync(Course course)
        {
            await _courseRepository.InsertCourseAsync(course);
        }

        public async Task DeleteCourseAsync(int courseId)
        {
            await _courseRepository.DeleteCourseAsync(courseId);
        }

        public async Task UpdateCourseAsync(Course course)
        { 
            await _courseRepository.UpdateCourseAsync(course);
        }
    }
}
