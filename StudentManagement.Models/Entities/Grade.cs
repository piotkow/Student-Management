using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models.Entities
{
    [Table("Grades")]
    public class Grade
    {
        [Key]
        public int GradeID { get; set; }

        [ForeignKey("Students")]
        public int StudentID { get; set; }

        [ForeignKey("Trainings")]
        public int TrainingID {  get; set; }

        public Student Student { get; set; }
        public Training Training { get; set; }

        [Required]
        [Range(1,100)]
        public float Score { get; set; }
        public string Remarks { get; set; }
    }
}
