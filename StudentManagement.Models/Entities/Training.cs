using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models.Entities
{
    [Table("Trainings")]
    public class Training
    {
        [Key]
        public int TrainingID { get; set; }
        [Required]
        public string Location { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string Topic { get; set; }

        public virtual ICollection<CourseTraining> CourseTrainings { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
