using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.DAL.Entities;
namespace Student.DAL.Interfaces
{
    public interface IOptionsRepository
    {
        IEnumerable<Options> GetOptions();
        List<Options> GetAllOptions();
        Options GetById(int id);

        IEnumerable<Options> GetByQuestionId(int id);

        void SaveOption(Options product, bool isSaveChanges = true);

        Options DeleteOption(int productId, bool isSaveChanges = true);

        void SaveChanges();
    }
}
