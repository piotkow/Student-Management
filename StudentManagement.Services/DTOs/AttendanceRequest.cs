using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Services.DTOs
{
    public class AttendanceRequest
    {
        public int UserID { get; set; }
        public int TrainingID { get; set; }
        public DateTime Date { get; set; }
        public bool Present { get; set; }
    }
}
