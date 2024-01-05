using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models.Entities
{
    public class UserCoaching
    {
        [ForeignKey("Users")]
        public int UserID { get; set; }

        public User User { get; set; }

        [ForeignKey("Coachings")]
        public int CoachingID { get; set; }

        public Coaching Coaching { get; set; }
    }
}