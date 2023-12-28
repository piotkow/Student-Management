using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models.Entities
{
    public class UserTraining
    {
        [ForeignKey("Users")]
        public int UserID { get; set; }

        [ForeignKey("Trainings")]
        public int TrainingID { get; set; }
    }
}
