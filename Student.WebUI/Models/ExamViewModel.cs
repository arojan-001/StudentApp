using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Student.WebUI.Models
{
    public class ExamViewModel
    {
        public int Id { get; set; }

        public int GroupId { get; set; }

        public int LessonId { get; set; }

        public DateTime ExamDate { get; set; }
        
        public int Duration { get; set; }
        
        public int FullMark { get; set; }

        public DateTime Created { get; set; }
    }
}