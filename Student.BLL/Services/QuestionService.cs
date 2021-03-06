using Student.BLL.Interfaces;
using Student.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.BLL.DTO;
using Student.BLL.Infrastructure;
using Student.DAL.Entities;

namespace Student.BLL.Services
{
    public class QuestionService : IQuestionService
    {
        IQuestionBankRepository Database { get; set; }

        public QuestionService(IQuestionBankRepository questionRepository)
        {
            Database = questionRepository;
        }

        public OperationDetails Create(QuestionBankDTO qnsDto)
        {
            QuestionBank qns = Database.GetById(qnsDto.Id);

            if (qns == null)
            {
                qns = new QuestionBank { ExamId = qnsDto.ExamId, Mark = qnsDto.Mark, Question = qnsDto.Question };
               var id = Database.SaveQuestion(qns).Id;
                return new OperationDetails(true, "Success ", id.ToString());
            }
            else
            {
               var id = Database.SaveQuestion(new QuestionBank() { ExamId = qnsDto.ExamId, Mark = qnsDto.Mark, Question = qnsDto.Question }).Id;
                return new OperationDetails(true, "Success ", id.ToString());
            }
        }

        public List<QuestionBankDTO> GetAll()
        {
            var qns = Database.GetQuestions();
            List<QuestionBankDTO> qnsDTO = new List<QuestionBankDTO>();
            foreach (var item in qns)
            {
                qnsDTO.Add(new QuestionBankDTO() { Id = item.Id, ExamId = item.ExamId, Question = item.Question });
            }
            return qnsDTO;
        }

        public QuestionBankDTO Delete(int id)
        {
            var qns = Database.DeleteQuestion(id);

            return new QuestionBankDTO() {  Id = qns.Id, Mark = qns.Mark, ExamId = qns.ExamId, Question = qns.Question };
        }

        public QuestionBankDTO GetById(int id)
        {
            var qns = Database.GetById(id);

            return new QuestionBankDTO() { Id = qns.Id, Mark = qns.Mark, ExamId = qns.ExamId, Question = qns.Question };
        }
        public int GetQuestionOrder()
        {
            var order = Database.GetAllQuestions().Count;
            return order;
        }
        public List<QuestionBankDTO> GetByExamId(int id)
        {
            var qns = Database.GetQuestions().Where(x=> x.ExamId == id);
            List<QuestionBankDTO> qnsDTO = new List<QuestionBankDTO>();
            foreach (var item in qns)
            {
                qnsDTO.Add(new QuestionBankDTO() { Id = item.Id, ExamId = item.ExamId, Question = item.Question, Mark = item.Mark });
            }
            return qnsDTO;
        }
        public static List<int> GetMark()
        {
            return new List<int>(new int[] { 1, 2, 3, 4, 5 });
        }

        public void Dispose()
        {
            return;
        }
    }
}
