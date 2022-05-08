using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.BLL.DTO
{
    public class ExamResultDTO
    {
        public int Id { get; set; }

        public string StudentId { get; set; }

        public int QuestionId { get; set; }

        public int option { get; set; }


    }
}
