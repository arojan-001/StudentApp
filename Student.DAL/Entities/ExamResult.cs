using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student.DAL.Entities
{
    public class ExamResult :ModelBase
    {   
        [Key]
        public int Id { get; set; }

        [ForeignKey("Students")]
        public string StudentId { get; set; }
        
        [ForeignKey("QuestionBank")]
        public int QuestionId { get; set; }

        public int StudentAnswer{ get; set; }

        public Students Students { get; set; }

        public QuestionBank QuestionBank { get; set; }



    }
}
