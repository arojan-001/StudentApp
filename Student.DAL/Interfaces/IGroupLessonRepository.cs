using Student.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DAL.Interfaces
{
    public interface IGroupLessonRepository
    {
        void AddLessonToGroup(GroupLesson groupLesson, bool isSaveChanges = true);

        IQueryable<GroupLesson> GetGroupLessons(int id);

        void SaveChanges();
    }
}
