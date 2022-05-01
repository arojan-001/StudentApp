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

        public IEnumerable<Exams> GetExams()
        {
            return GetAll<Exams>();
        }

        public Exams GetById(int id)
        {
            return GetAll<Exams>().FirstOrDefault(x => x.Id == id);
        }

        public void SaveExam(Exams product, bool isSaveChanges = true)
        {
            var dbProduct = Find<Exams>(product.Id);
            if (dbProduct == null)
                Add<Exams>(product);
            else
                SetValues(product, dbProduct);
            if (isSaveChanges)
                SaveChanges();
        }

        public Exams DeleteExam(int id, bool isSaveChanges = true)
        {
            var dbEntry = Find<Exams>(id);
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
