using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DAL.Entities
{
    public class Exams : ModelBase
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("StudentGroup")]
        public int GroupId { get; set; }

        [ForeignKey("Lesson")]
        public int LessonId { get; set; }

        public DateTime ExamDate { get; set; }

        public int Duration { get; set; }

        public int FullMark { get; set; }

        public DateTime Created { get; set; }
    }
}
