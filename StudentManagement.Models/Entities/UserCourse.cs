using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models.Entities
{
    public class UserCourse
    {
        [ForeignKey("Users")]
        public int UserID { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("Courses")]
        public int CourseID { get; set; }
        public virtual Course Course { get; set; }
    }
}
