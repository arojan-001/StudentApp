using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.BLL.DTO
{
    public class OptionsDTO
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }

        public string Answer { get; set; }

        public int Correct_Answer { get; set; }
        public bool BoolValue
        {
            get { return Correct_Answer == 1; }
            set { Correct_Answer = value ? 1 : 0; }
        }
    }
}
