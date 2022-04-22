using Student.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.DAL.Entities;

namespace Student.DAL.Repositories
{
    public class LessonRepository : BaseRepository, ILessonRepository
    {
        public LessonRepository(string connectionString) : base(connectionString)
        {

        }
        public void AddLesson(Lesson lesson, bool isSaveChanges = true)
        {
            var dbProduct = Find<Lesson>(lesson.LessonId);
            if (dbProduct == null)
                Add<Lesson>(lesson);
            else
                SetValues(lesson, dbProduct);
            if (isSaveChanges)
                SaveChanges();
        }

        public Lesson DeleteLesson(int lessonId, bool isSaveChanges = true)
        {
            var dbEntry = Find<Lesson>(lessonId);
            if (dbEntry != null)
            {
                Remove(dbEntry);
                if (isSaveChanges)
                    SaveChanges();
            }
            return dbEntry;
        }

        public Lesson GetById(int id)
        {
            return GetAll<Lesson>().FirstOrDefault(x => x.LessonId == id);
        }

        public IEnumerable<Lesson> GetLessons()
        {
            return GetAll<Lesson>();
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
