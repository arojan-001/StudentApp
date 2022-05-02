using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DAL.Entities
{
    [Table("Student")]
    public class Students : ModelBase
    {
        [Key]
        public string Id { get; set; }

        public int GroupId { get; set; }

    }
}
