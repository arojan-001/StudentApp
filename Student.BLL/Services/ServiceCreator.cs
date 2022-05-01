using Student.BLL.Interfaces;
using Student.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.BLL.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public IUserService CreateUserService(string connection)
        {
            return new UserService(new IdentityUnitOfWork(connection));
        }

        public IStudentGroupService CreateStudentGroupService(string connection)
        {
            return new StudentGroupService(new StudentGroupRepository(connection));
        }
        public IStudentService CreateStudentService(string connection)
        {
            return new StudentService(new StudentRepository(connection));
        }

        public ILessonService CreateLessonService(string connection)
        {
            return new LessonService(new LessonRepository(connection));
        }
    }
}
