using Student.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DAL.Interfaces
{
    public interface IStudentGroupRepository
    {
        IEnumerable<StudentGroup> GetStudentGroups();

        StudentGroup GetById(int id);

        void SaveStudentGroup(StudentGroup product, bool isSaveChanges = true);

        StudentGroup DeleteStudentGroup(int productId, bool isSaveChanges = true);

        void SaveChanges();
    }
}
