using AutoMapper;
using StudentManagement.Models.Entities;
using StudentManagement.Services.Interfaces;
using StudentManagment.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using StudentManagment.Data.Repositories.Interfaces;

namespace StudentManagement.Services.Services
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IMapper _mapper;

        public GradeService(IGradeRepository gradeRepository, IMapper mapper)
        {
            _gradeRepository = gradeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Grade>> GetGradesAsync()
        {
            return await _gradeRepository.GetGradesAsync();
        }

        public async Task<Grade> GetGradeByIdAsync(int gradeId)
        {
            return await _gradeRepository.GetGradeByIdAsync(gradeId);
        }

        public async Task InsertGradeAsync(Grade grade)
        {
            await _gradeRepository.InsertGradeAsync(grade);
        }

        public async Task DeleteGradeAsync(int gradeId)
        {
            await _gradeRepository.DeleteGradeAsync(gradeId);
        }

        public async Task UpdateGradeAsync(Grade grade)
        {
            await _gradeRepository.UpdateGradeAsync(grade);
        }
    }
}

