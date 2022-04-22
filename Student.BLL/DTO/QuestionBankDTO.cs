using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.BLL.DTO
{
    class QuestionBankDTO
    {
        public int Id { get; set; }

        public int ExamId { get; set; }

        public int Mark { get; set; }

        public String Question { get; set; }
    }
}
