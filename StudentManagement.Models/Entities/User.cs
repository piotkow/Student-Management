using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models.Entities
{
    public enum Role
    {
        Administrator, 
        Instructor,
        Student
    };


    [Table("Users")]
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9]{5,19}$", ErrorMessage = "Characters are not allowed")]
        public string Username { get; set; }

        [Required]
        [StringLength(30)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d!@#$%^&*()]{8,20}$", ErrorMessage = "Characters are not allowed")]
        public string Password { get; set; }
        public Role Role { get; set; }

        [Required]
        [StringLength(30)]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        public virtual Student Student { get; set; }
        public virtual Instructor Instructor { get; set; }
        public virtual ICollection<UserCourse> UserCourses { get; set; }
    }


}
