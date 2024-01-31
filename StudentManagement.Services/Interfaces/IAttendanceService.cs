using StudentManagement.Models.Entities;
using StudentManagement.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Services.Interfaces
{
    public interface IAttendanceService
    {
        Task<IEnumerable<Attendance>> GetAttendancesAsync();
        Task<Attendance> GetAttendanceByIdAsync(int attendanceId);
        Task<Attendance> InsertAttendanceAsync(AttendanceRequest attendanceReq);
        Task DeleteAttendanceAsync(int attendanceId);
        Task UpdateAttendanceAsync(int attendanceId, AttendanceRequest attendanceReq);
    }
}
