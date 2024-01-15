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
    public class AttendanceService : IAttendanceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AttendanceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Attendance>> GetAttendancesAsync()
        {
            return await _unitOfWork.AttendanceRepository.GetAttendancesAsync();
        }

        public async Task<Attendance> GetAttendanceByIdAsync(int attendanceId)
        {
            return await _unitOfWork.AttendanceRepository.GetAttendanceByIdAsync(attendanceId);
        }

        public async Task InsertAttendanceAsync(Attendance attendance)
        {
            await _unitOfWork.AttendanceRepository.InsertAttendanceAsync(attendance);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAttendanceAsync(int attendanceId)
        {
            await _unitOfWork.AttendanceRepository.DeleteAttendanceAsync(attendanceId);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAttendanceAsync(Attendance attendance)
        {
            await _unitOfWork.AttendanceRepository.UpdateAttendanceAsync(attendance);
            await _unitOfWork.SaveAsync();
        }
    }

}
