using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Services.DTOs.Attendance
{
    public class AttendanceUserResponse
    {
        public DateTime Date { get; set; }
        public bool Present { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
