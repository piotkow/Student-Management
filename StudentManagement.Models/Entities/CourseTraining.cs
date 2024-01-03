using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models.Entities
{
    [Table("CourseTrainings")]
    public class CourseTraining
    {
        [ForeignKey("Courses")]
        public int CourseID { get; set; }
        public Course Course { get; set; }
        [ForeignKey("Trainings")]
        public int TrainingID { get; set; }
        public Training Training { get; set;}
    }
}
