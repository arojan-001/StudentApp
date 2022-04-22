using Student.BLL.DTO;
using Student.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Student.WebUI.Models
{
    public class LessonsViewModel
    {
        public List<Lesson> Lessons { get; set; }

        public List<Exam> Exams { get; set; }
    }
}