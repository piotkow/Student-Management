using StudentManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagment.Data.Repositories.Interfaces
{
    public interface ICoachingRepository : IDisposable
    {
        IEnumerable<Coaching> GetCoachings();
        Coaching GetCoachingById(int id);
        void InsertCoaching(Coaching coaching);
        void DeleteCoaching(int id);
        void UpdateCoaching(Coaching coaching);
        void Save();
    }
}
