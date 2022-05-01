using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DAL.Entities
{
    public class Exam : ModelBase
    {
        [Key]
        public int ExamId { get; set; }

        [ForeignKey("StudentGroup")]
        public int GroupId { get; set; }

        [ForeignKey("Lesson")]
        public int LessonId { get; set; }

        public DateTime ExamDate { get; set; }

        public int Duration { get; set; }

        public int FullMark { get; set; }

        public DateTime Created { get; set; }

        public ICollection<Evaluation> Evaluations { get; set; }

        public StudentGroup StudentGroup { get; set; }

        public Lesson Lesson { get; set; }
    }
}
