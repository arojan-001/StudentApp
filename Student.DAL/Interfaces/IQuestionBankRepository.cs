using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.DAL.Entities;
namespace Student.DAL.Interfaces
{
    public interface IQuestionBankRepository
    {
        IEnumerable<QuestionBank> GetQuestion();

        QuestionBank GetById(int id);

        void SaveQuestion(QuestionBank product, bool isSaveChanges = true);

        QuestionBank DeleteQuestion(int productId, bool isSaveChanges = true);

        void SaveChanges();
    }
}
