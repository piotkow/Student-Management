using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models.Entities
{
    [Table("Attendances")]
    public class Attendance
    {
        [Key]
        public int AttendanceID { get; set; }

        [ForeignKey("Students")]
        public int StudentID { get; set; }

        [ForeignKey("Trainings")]
        public int TrainingID { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public bool Present { get; set; } 
    }
}
