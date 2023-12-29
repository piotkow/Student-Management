//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace StudentManagement.Models.Entities
//{
//    [Table("StudentCourses")]
//    public class StudentCourse
//    {
//        [ForeignKey("Students")]
//        public int StudentID { get; set; }
//        public Student Student { get; set; }
//        [ForeignKey("Courses")]
//        public int CourseID { get; set; }
//        public Course Course { get; set;}
//    }
//}
