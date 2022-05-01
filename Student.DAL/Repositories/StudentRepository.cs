using Student.DAL.Entities;
using Student.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DAL.Repositories
{
    public class StudentRepository : BaseRepository, IStudentRepository
    {
        public StudentRepository(string connectionString) : base(connectionString)
        {

        }

        public IEnumerable<Students> GetStudents()
        {
            return GetAll<Students>();
        }

        public Students GetById(string id)
        {
            return GetAll<Students>().FirstOrDefault(x => x.Id == id);
        }

        public void SaveStudents(Students product, bool isSaveChanges = true)
        {
            var dbProduct = Find<Students>(product.Id);
            if (dbProduct == null)
                Add<Students>(product);
            else
                SetValues(product, dbProduct);
            if (isSaveChanges)
                SaveChanges();
        }

        public Students DeleteStudents(string id, bool isSaveChanges = true)
        {
            var dbEntry = Find<Students>(id);
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
