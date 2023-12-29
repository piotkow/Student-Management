using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models.Entities
{
    [Table("Courses")]
    public class Course
    {
        [Key]
        public int CourseID { get; set; }

        [Required]
        [StringLength(30)]
        public string CourseName { get; set; }
        public string Description { get; set; }
        //public virtual ICollection<StudentCourse> StudentCourses { get; set; }
        public virtual ICollection<UserCourse> UserCourses { get; set; }
        public virtual ICollection<CourseTraining> CourseTrainings { get; set; }
        public virtual Instructor Instructor { get; set; }
    }
}
