using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.BLL.DTO
{
    class ExamsDTO
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
