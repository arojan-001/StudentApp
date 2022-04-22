using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DAL.Entities
{ 
    [Table("StudentGroup")]
    public class StudentGroup : ModelBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Exam> Exams { get; set; }

        public ICollection<GroupLesson> GroupLessons { get; set; }
    }
}
