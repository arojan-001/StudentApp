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
    public class OptionsService : IOptionsService
    {
        IOptionsRepository Database { get; set; }

        public OptionsService(IOptionsRepository optionsRepository)
        {
            Database = optionsRepository; 
        }
        
        public OperationDetails Create(OptionsDTO ansDTO)
        {
            Options ans = Database.GetById(ansDTO.Id);

            if (ans == null)
            {
                ans = new Options { Id = ansDTO.Id, Answer = ansDTO.Answer, QuestionId = ansDTO.QuestionId, Correct_Answer = ansDTO.Correct_Answer };
                Database.SaveOption(ans);
                return new OperationDetails(true, "Success ", "");
            }
            else
            {
                Database.SaveOption(new Options() { Id = ans.Id, Answer = ans.Answer, QuestionId = ans.QuestionId, Correct_Answer = ans.Correct_Answer });
                return new OperationDetails(true, "Success ", "");
            }
        }

        public List<OptionsDTO> GetAll()
        {
            var ans = Database.GetOptions();
            List<OptionsDTO> ansDTO = new List<OptionsDTO>();
            foreach (var item in ans)
            {
                ansDTO.Add(new OptionsDTO() { Id = item.Id, Answer = item.Answer, Correct_Answer = item.Correct_Answer, QuestionId = item.QuestionId });
            }
            return ansDTO;
        }
        public List<OptionsDTO> GetbyQuestionid(int id)
        {
            var ans = Database.GetByQuestionId(id);
            List<OptionsDTO> ansDTO = new List<OptionsDTO>();
            foreach (var item in ans)
            {
                ansDTO.Add(new OptionsDTO() { Id = item.Id, Answer = item.Answer, Correct_Answer = item.Correct_Answer, QuestionId = item.QuestionId });
            }
            return ansDTO;
        }

        public OptionsDTO Delete(int id)
        {
            var ans = Database.DeleteOption(id);

            return new OptionsDTO() { Id = ans.Id, Answer = ans.Answer, Correct_Answer = ans.Correct_Answer, QuestionId = ans.QuestionId };
        }

        public OptionsDTO GetById(int id)
        {
            var ans = Database.GetById(id);

            return new OptionsDTO() { Id = ans.Id, Answer = ans.Answer, Correct_Answer = ans.Correct_Answer, QuestionId = ans.QuestionId };
        }
        public int GetOptionsOrder()
        {
            var order = Database.GetAllOptions().Count;
            return order;
        }

        public void Dispose()
        {
            return;
        }
    }
}
