using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DAL.Entities
{
    public class Student : ModelBase
    {
        [Key]
        public int StudentId { get; set; }

        public StudentGroup Group { get; set; }
    }
}
