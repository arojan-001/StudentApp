using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student.DAL.Entities
{
    public class QuestionBank : ModelBase
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Exam")]
        public int ExamId { get; set; }

        public int Mark { get; set; }

        public String Question { get; set; }

        public Exam Exam { get; set; }

       // public ICollection<QuestionBank> Questions { get; set; }
    }
}
