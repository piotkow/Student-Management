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
    public class CourseTrainingService
    {
        private readonly ICourseTrainingRepository _courseTrainingRepository;
        private readonly IMapper _mapper;

        public CourseTrainingService(ICourseTrainingRepository courseTrainingRepository, IMapper mapper)
        {
            _courseTrainingRepository = courseTrainingRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CourseTraining>> GetCourseTrainingsAsync()
        {
            return await _courseTrainingRepository.GetCourseTrainingsAsync();
        }

        public async Task<CourseTraining> GetCourseTrainingByIdAsync(int courseId, int trainingId)
        {
            return await _courseTrainingRepository.GetCourseTrainingByIdAsync(courseId, trainingId);
        }

        public async Task InsertCourseTrainingAsync(CourseTraining courseTraining)
        {

            await _courseTrainingRepository.InsertCourseTrainingAsync(courseTraining);
        }

        public async Task DeleteCourseTrainingAsync(int courseId,int trainingId)
        {
            await _courseTrainingRepository.DeleteCourseTrainingAsync(courseId,trainingId);
        }

        public async Task UpdateCourseTrainingAsync(CourseTraining courseTraining)
        {
            await _courseTrainingRepository.UpdateCourseTrainingAsync(courseTraining);
        }
    }
}
