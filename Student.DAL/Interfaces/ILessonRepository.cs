using Student.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DAL.Interfaces
{
    public interface ILessonRepository
    {
        IEnumerable<Lesson> GetLessons();

        Lesson GetById(int id);

        void AddLesson(Lesson lesson, bool isSaveChanges = true);

        Lesson DeleteLesson(int lessonId, bool isSaveChanges = true);

        void SaveChanges();
    }
}
