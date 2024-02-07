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
    public class CourseTrainingService : ICourseTrainingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CourseTrainingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CourseTraining>> GetCourseTrainingsAsync()
        {
            return await _unitOfWork.CourseTrainingRepository.GetCourseTrainingsAsync();
        }

        public async Task<IEnumerable<CourseTraining>> GetCourseTrainingsByCourseIdAsync(int courseId)
        {
            return await _unitOfWork.CourseTrainingRepository.GetCourseTrainingsByCourseIdAsync(courseId);
        }

        public async Task<CourseTraining> GetCourseTrainingByIdAsync(int courseId, int trainingId)
        {
            return await _unitOfWork.CourseTrainingRepository.GetCourseTrainingByIdAsync(courseId, trainingId);
        }

        public async Task InsertCourseTrainingAsync(CourseTraining courseTraining)
        {
            await _unitOfWork.CourseTrainingRepository.InsertCourseTrainingAsync(courseTraining);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteCourseTrainingAsync(int courseId, int trainingId)
        {
            await _unitOfWork.CourseTrainingRepository.DeleteCourseTrainingAsync(courseId, trainingId);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateCourseTrainingAsync(CourseTraining courseTraining)
        {
            await _unitOfWork.CourseTrainingRepository.UpdateCourseTrainingAsync(courseTraining);
            await _unitOfWork.SaveAsync();
        }
    }

}
