using AutoMapper;
using StudentManagement.Models.Entities;
using StudentManagement.Services.Interfaces;
using StudentManagment.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using StudentManagment.Data.Repositories.Interfaces;
using StudentManagment.Data.UnitOfWork;
using StudentManagement.Services.DTOs.Grade;

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

        public async Task<Grade> InsertGradeAsync(GradeRequest gradeReq)
        {
            await _unitOfWork.BeginTransactionAsync();
            var grade = _mapper.Map<Grade>(gradeReq);
            await _unitOfWork.GradeRepository.InsertGradeAsync(grade);
            await _unitOfWork.CommitAsync();
            return grade;
        }

        public async Task DeleteGradeAsync(int gradeId)
        {
            await _unitOfWork.GradeRepository.DeleteGradeAsync(gradeId);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateGradeAsync(int gradeId, GradeRequest gradeReq)
        {
            await _unitOfWork.BeginTransactionAsync();
            var grade = await _unitOfWork.GradeRepository.GetGradeByIdAsync(gradeId);
            grade.UserID = gradeReq.UserID;
            grade.TrainingID = gradeReq.TrainingID;
            grade.Score = gradeReq.Score;
            grade.Remarks = gradeReq.Remarks;
            await _unitOfWork.GradeRepository.UpdateGradeAsync(grade);
            await _unitOfWork.CommitAsync();
        }
    }

}

