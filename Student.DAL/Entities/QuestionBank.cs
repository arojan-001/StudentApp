using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student.DAL.Entities
{
    class QuestionBank : ModelBase
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Exams")]
        public int ExamId { get; set; }

        public int Mark { get; set; }

        public String Question { get; set; }
    }
}
