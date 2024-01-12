using AutoMapper;
using StudentManagement.Models.Entities;
using StudentManagement.Services.Interfaces;
using StudentManagment.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Services.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IMapper _mapper;

        public AttendanceService(IAttendanceRepository attendanceRepository, IMapper mapper)
        {
            _attendanceRepository = attendanceRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Attendance>> GetAttendancesAsync()
        {
            return await _attendanceRepository.GetAttendancesAsync();
        }

        public async Task<Attendance> GetAttendanceByIdAsync(int attendanceId)
        {
            return await _attendanceRepository.GetAttendanceByIdAsync(attendanceId);
        }

        public async Task InsertAttendanceAsync(Attendance attendance)
        {
            await _attendanceRepository.InsertAttendanceAsync(attendance);
        }

        public async Task DeleteAttendanceAsync(int attendanceId)
        {
            await _attendanceRepository.DeleteAttendanceAsync(attendanceId);
        }

        public async Task UpdateAttendanceAsync(Attendance attendance)
        {
            await _attendanceRepository.UpdateAttendanceAsync(attendance);
        }
    }
}
