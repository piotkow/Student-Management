using StudentManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagment.Data.Repositories.Interfaces
{
    public interface IInstructorRepository : IDisposable
    {
        IEnumerable<Instructor> GetInstructors();
        Instructor GetInstructorById(int id);
        void InsertInstructor(Instructor instructor);
        void DeleteInstructor(int id);
        void UpdateInstructor(Instructor instructor);
        void Save();
    }
}
