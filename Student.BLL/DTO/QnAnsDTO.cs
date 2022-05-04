using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.BLL.DTO
{
    public class QnAnsDTO
    {
        public QuestionBankDTO question { get; set; }
        public List<OptionsDTO> options { get; set; }
    }
}
