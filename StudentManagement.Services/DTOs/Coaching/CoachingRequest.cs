using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Services.DTOs.Coaching
{
    public class CoachingRequest
    {
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Topic { get; set; }
        public string Feedback { get; set; }
    }
}
