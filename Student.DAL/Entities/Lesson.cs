using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DAL.Entities
{
    public class Lesson : ModelBase
    {

        [Key]
        public int LessonId { get; set; }

        public string Name { get; set; }

        public ICollection<Exam> Exams { get; set; }

        public ICollection<Lesson> Lessons { get; set; }
    }
}
