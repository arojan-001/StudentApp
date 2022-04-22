using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student.DAL.Entities
{
    class Options : ModelBase
    {
        [Key]
        public int Id { get; set; }
       
        [ForeignKey("QuestionBank")]
        public int ExamId { get; set; }

        public string Answer { get; set; }

        public int Correct_Answer { get; set; }
    }
}
