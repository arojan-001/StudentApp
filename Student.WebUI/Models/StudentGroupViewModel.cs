using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Student.WebUI.Models
{
    public class StudentGroupViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}