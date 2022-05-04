using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.DAL.Entities;
using Student.DAL.Interfaces;
namespace Student.DAL.Repositories
{
    public class OptionsRepository : BaseRepository, IOptionsRepository
    {
        public OptionsRepository(string connectionString) : base(connectionString)
        {


        }

        public IEnumerable<Options> GetOptions()
        {
            return GetAll<Options>();
        }

        public List<Options> GetAllOptions()
        {
            return GetAll<Options>().ToList();
        }

        public Options GetById(int id)
        {
            return GetAll<Options>().FirstOrDefault(x => x.Id == id);
        }

        public void SaveOption(Options product, bool isSaveChanges = true)
        {
            var dbProduct = Find<Options>(product.Id);
            if (dbProduct == null)
                Add<Options>(product);
            else
                SetValues(product, dbProduct);
            if (isSaveChanges)
                SaveChanges();
        }

        public Options DeleteOption(int id, bool isSaveChanges = true)
        {
            var dbEntry = Find<Options>(id);
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

        public IEnumerable<Options> GetByQuestionId(int id)
        {
            return GetAll<Options>().Where(x => x.QuestionId == id);
        }
    }
}
