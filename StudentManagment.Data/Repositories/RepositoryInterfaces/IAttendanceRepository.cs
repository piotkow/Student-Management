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
        IEnumerable<Attendance> GetAttendances();
        Attendance GetAttendanceById(int id);
        void InsertAttendance(Attendance attendance);
        void DeleteAttendance(int id);
        void UpdateAttendance(Attendance attendance);
        void Save();
    }
}
