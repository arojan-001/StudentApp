using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.DAL.Entities;
using Student.DAL.Interfaces;
namespace Student.DAL.Repositories
{
    public class QuestionBankRepository : BaseRepository, IQuestionBankRepository
    {
        private QuestionBank s;

        public QuestionBankRepository(string connectionString) : base(connectionString)
        {

        }

        public IEnumerable<QuestionBank> GetQuestions()
        {
            return GetAll<QuestionBank>();
        }

        public List<QuestionBank> GetAllQuestions()
        {
            return GetAll<QuestionBank>().ToList();
        }

        public QuestionBank GetById(int id)
        {
            return GetAll<QuestionBank>().FirstOrDefault(x => x.Id == id);
        }

        public QuestionBank SaveQuestion(QuestionBank product, bool isSaveChanges = true)
        {
            var dbProduct = Find<QuestionBank>(product.Id);
            if (dbProduct == null)
               s = Add<QuestionBank>(product);
            else
                SetValues(product, dbProduct);
            if (isSaveChanges)
                SaveChanges();
            return dbProduct == null? product : dbProduct;

        }

        public QuestionBank DeleteQuestion(int id, bool isSaveChanges = true)
        {
            var dbEntry = Find<QuestionBank>(id);
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

        public IEnumerable<QuestionBank> GetByExamId(int id)
        {
            return GetAll<QuestionBank>().Where(x => x.ExamId == id);
        }

    }
}
