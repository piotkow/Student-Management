using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Services.DTOs.Course
{
    public class CourseResponse
    { 
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
    }
}
