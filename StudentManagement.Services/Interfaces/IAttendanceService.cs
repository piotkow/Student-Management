using StudentManagement.Models.Entities;
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
        Task InsertAttendanceAsync(Attendance attendance);
        Task DeleteAttendanceAsync(int attendanceId);
        Task UpdateAttendanceAsync(Attendance attendance);
    }
}
