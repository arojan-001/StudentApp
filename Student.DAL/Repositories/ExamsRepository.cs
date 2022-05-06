using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.DAL.Interfaces;
using Student.DAL.Entities;
namespace Student.DAL.Repositories
{
    public class ExamsRepository : BaseRepository, IExamsRepositoty
    {
        public ExamsRepository(string connectionString) : base(connectionString)
        {

        }

        public IEnumerable<Exam> GetExams()
        {
            return GetAll<Exam>();
        }

        public Exam GetById(int id)
        {
            return GetAll<Exam>().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Exam> GetByGroupId(int id)
        {
            return GetAll<Exam>().Where(x => x.GroupId == id);
        }

        public void SaveExam(Exam product, bool isSaveChanges = true)
        {
            var dbProduct = Find<Exam>(product.Id);
            if (dbProduct == null)
                Add<Exam>(product);
            else
                SetValues(product, dbProduct);
            if (isSaveChanges)
                SaveChanges();
        }

        public Exam DeleteExam(int id, bool isSaveChanges = true)
        {
            var dbEntry = Find<Exam>(id);
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
