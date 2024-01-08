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

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        [Required]
        [StringLength(20)]
        public DateTime DateOfBirth { get; set; }

        public string Phone { get; set; }
        public virtual ICollection<UserCourse> UserCourses { get; set; }
        public virtual ICollection<UserCoaching> UserCoachings { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }
    }


}
