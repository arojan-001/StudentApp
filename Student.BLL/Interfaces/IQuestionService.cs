using Student.BLL.DTO;
using Student.BLL.Infrastructure;
using Student.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.BLL.Interfaces
{
    public interface IQuestionService : IDisposable
    {
        OperationDetails Create(QuestionBankDTO questionDTO);
        List<QuestionBankDTO> GetAll();

        QuestionBankDTO Delete(int id);

        QuestionBankDTO GetById(int id);

        List<QuestionBankDTO> GetByExamId(int id);
    }
}
