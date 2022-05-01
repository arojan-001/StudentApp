using Student.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DAL.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Students> GetStudents();

        Students GetById(string id);

        void SaveStudents(Students product, bool isSaveChanges = true);

        Students DeleteStudents(string productId, bool isSaveChanges = true);

        void SaveChanges();
    }
}
