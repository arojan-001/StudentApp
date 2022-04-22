using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DAL.Entities
{
    public class GroupLesson : ModelBase
    {
        [Key]
        public int GroupLessonId  { get; set; }

        [ForeignKey("StudentGroup")]
        public int GroupId { get; set; }

        [ForeignKey("Lesson")]
        public int LessonId { get; set; }

        public StudentGroup StudentGroup { get; set; }

        public Lesson Lesson { get; set; }
    }
}
