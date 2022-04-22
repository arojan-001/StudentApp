using Student.DAL.Entities;
using Student.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DAL.Repositories
{
    public class StudentGroupRepository : BaseRepository, IStudentGroupRepository
    {
        public StudentGroupRepository(string connectionString) : base(connectionString)
        {

        }

        public IEnumerable<StudentGroup> GetStudentGroups()
        {
            return GetAll<StudentGroup>();
        }

        public StudentGroup GetById(int id)
        {
            return GetAll<StudentGroup>().FirstOrDefault(x => x.Id == id);
        }

        public void SaveStudentGroup(StudentGroup product, bool isSaveChanges = true)
        {
            var dbProduct = Find<StudentGroup>(product.Id);
            if (dbProduct == null)
                Add<StudentGroup>(product);
            else
                SetValues(product, dbProduct);
            if (isSaveChanges)
                SaveChanges();
        }

        public StudentGroup DeleteStudentGroup(int id, bool isSaveChanges = true)
        {
            var dbEntry = Find<StudentGroup>(id);
            if (dbEntry != null)
            {
                Remove(dbEntry);
                if (isSaveChanges)
                    SaveChanges();
            }
            return dbEntry;
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
