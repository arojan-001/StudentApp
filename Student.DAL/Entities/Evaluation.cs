using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DAL.Entities
{
    public class Evaluation : ModelBase
    {
        [Key]
        public int EvaluationId { get; set; }

        [ForeignKey("Exam")]
        public int ExamId { get; set; }

        public string UserId { get; set; }

        public int Value { get; set; }

        public Exam Exam { get; set; }
    }
}
