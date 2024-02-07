using StudentManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagment.Data.Repositories.Interfaces
{
    public interface IAttendanceRepository : IDisposable
    {
        Task<IEnumerable<Attendance>> GetAttendancesAsync();
        Task<Attendance> GetAttendanceByIdAsync(int id);
        Task InsertAttendanceAsync(Attendance attendance);
        Task UpdateAttendanceAsync(Attendance attendance);
        Task DeleteAttendanceAsync(int id);
        Task SaveAsync();
    }
}
