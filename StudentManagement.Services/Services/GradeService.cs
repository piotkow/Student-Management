using AutoMapper;
using StudentManagement.Models.Entities;
using StudentManagement.Services.Interfaces;
using StudentManagment.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using StudentManagment.Data.Repositories.Interfaces;
using StudentManagment.Data.UnitOfWork;

namespace StudentManagement.Services.Services
{
    public class GradeService : IGradeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GradeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Grade>> GetGradesAsync()
        {
            return await _unitOfWork.GradeRepository.GetGradesAsync();
        }

        public async Task<Grade> GetGradeByIdAsync(int gradeId)
        {
            return await _unitOfWork.GradeRepository.GetGradeByIdAsync(gradeId);
        }

        public async Task InsertGradeAsync(Grade grade)
        {
            await _unitOfWork.GradeRepository.InsertGradeAsync(grade);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteGradeAsync(int gradeId)
        {
            await _unitOfWork.GradeRepository.DeleteGradeAsync(gradeId);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateGradeAsync(Grade grade)
        {
            await _unitOfWork.GradeRepository.UpdateGradeAsync(grade);
            await _unitOfWork.SaveAsync();
        }
    }

}

