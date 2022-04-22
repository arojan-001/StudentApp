using Student.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.DAL.Entities;

namespace Student.DAL.Repositories
{
    public class GroupLessonRepository : BaseRepository, IGroupLessonRepository
    {
        public GroupLessonRepository(string connectionString) : base(connectionString)
        {

        }
        public void AddLessonToGroup(GroupLesson groupLesson, bool isSaveChanges = true)
        {
            Add<GroupLesson>(groupLesson);
            if (isSaveChanges)
                SaveChanges();
        }
        

        public IQueryable<GroupLesson> GetGroupLessons(int id)
        {
            return GetAll<GroupLesson>().Where(x => x.GroupId == id);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
