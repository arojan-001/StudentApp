using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Student.BLL.DTO;

namespace Student.WebUI.Models
{
    public class QuestionAnswerViewModel
    {
        public QuestionBankDTO question { get; set; }

        public List<OptionsDTO> options { get; set; }
    }
}