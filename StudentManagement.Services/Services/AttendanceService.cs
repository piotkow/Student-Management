using AutoMapper;
using StudentManagement.Models.Entities;
using StudentManagement.Services.DTOs.Attendance;
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

        public async Task<Attendance> InsertAttendanceAsync(AttendanceRequest attendanceReq)
        {
            await _unitOfWork.BeginTransactionAsync();
            var attendance = _mapper.Map<Attendance>(attendanceReq);
            await _unitOfWork.AttendanceRepository.InsertAttendanceAsync(attendance);
            await _unitOfWork.CommitAsync();
            return attendance;
        }

        public async Task DeleteAttendanceAsync(int attendanceId)
        {
            await _unitOfWork.AttendanceRepository.DeleteAttendanceAsync(attendanceId);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAttendanceAsync(int attendanceId, AttendanceRequest attendanceReq)
        {
            await _unitOfWork.BeginTransactionAsync();
            var attendance = await _unitOfWork.AttendanceRepository.GetAttendanceByIdAsync(attendanceId);
            attendance.TrainingID = attendanceReq.TrainingID;
            attendance.Date = attendanceReq.Date;
            attendance.Present = attendanceReq.Present;
            attendance.UserID = attendanceReq.UserID;
            await _unitOfWork.AttendanceRepository.UpdateAttendanceAsync(attendance);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<AttendanceUserResponse>> GetAttendanceByTrainingId(int trainingId)
        {
            await _unitOfWork.BeginTransactionAsync();
            var attendanceList = await _unitOfWork.AttendanceRepository.GetAttendancesAsync();
            attendanceList = attendanceList.Where(at => at.TrainingID == trainingId);
            var attendanceUserResponses = _mapper.Map<IEnumerable<Attendance>, IEnumerable<AttendanceUserResponse>>(attendanceList);
            await _unitOfWork.CommitAsync();
            return attendanceUserResponses;
        }

    }

}
