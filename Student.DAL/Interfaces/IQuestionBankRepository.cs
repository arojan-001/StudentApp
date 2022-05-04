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
        IEnumerable<QuestionBank> GetQuestions();

        List<QuestionBank> GetAllQuestions();
        QuestionBank GetById(int id);

        IEnumerable<QuestionBank> GetByExamId(int id);

        void SaveQuestion(QuestionBank product, bool isSaveChanges = true);

        QuestionBank DeleteQuestion(int productId, bool isSaveChanges = true);

        void SaveChanges();
    }
}
