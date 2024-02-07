using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Services.DTOs.Grade
{
    public class GradeRequest
    {
        public int UserID { get; set; }
        public int TrainingID { get; set; }
        public float Score { get; set; }
        public string Remarks { get; set; } 
    }
}
