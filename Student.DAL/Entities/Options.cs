using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student.DAL.Entities
{
    public class Options : ModelBase
    {
        [Key]
        public int Id { get; set; }
       
        [ForeignKey("QuestionBank")]
        public int QuestionId { get; set; }

        public string Answer { get; set; }

        public int Correct_Answer { get; set; }

        public QuestionBank QuestionBank { get; set; }
    }
}
