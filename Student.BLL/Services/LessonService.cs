using Student.BLL.Interfaces;
using Student.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.BLL.DTO;
using Student.BLL.Infrastructure;
using Student.DAL.Entities;

namespace Student.BLL.Services
{
    public class LessonService : ILessonService
    {
        ILessonRepository Database { get; set; }

        public LessonService(ILessonRepository lessonRepository)
        {
            Database = lessonRepository;
        }

        public OperationDetails Create(LessonDTO lessonDto)
        {
            Lesson lesson = Database.GetById(lessonDto.LessonId);
            if (lesson == null)
            {
                lesson = new Lesson { LessonId = lessonDto.LessonId, Name = lessonDto.Name };
                Database.AddLesson(lesson);
                return new OperationDetails(true, "Success ", "");
            }
            else
            {
                Database.AddLesson(new Lesson() { LessonId = lessonDto.LessonId, Name = lessonDto.Name });
                return new OperationDetails(true, "Success ", "");
            }
        }

        public List<LessonDTO> GetAll()
        {
            var lessons = Database.GetLessons();
            List<LessonDTO> lessonDTO = new List<LessonDTO>();
            foreach (var item in lessons)
            {
                lessonDTO.Add(new LessonDTO() { LessonId = item.LessonId, Name = item.Name });
            }
            return lessonDTO;
        }

        public LessonDTO Delete(int id)
        {
            var dt = Database.DeleteLesson(id);

            return new LessonDTO() { LessonId = dt.LessonId, Name = dt.Name };
        }

        public LessonDTO GetById(int id)
        {
            var dt = Database.GetById(id);

            return new LessonDTO() { LessonId = dt.LessonId, Name = dt.Name };
        }

        public void Dispose()
        {
            return;
        }
    }
}
