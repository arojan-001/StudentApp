using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.BLL.Interfaces
{
    public interface IServiceCreator
    {
        IUserService CreateUserService(string connection);

        IStudentGroupService CreateStudentGroupService(string connection);
        IStudentService CreateStudentService(string connection);

        ILessonService CreateLessonService(string connection);

        IExamService CreateExamService(string connection);
       
        IQuestionService CreateQuestionService(string connection);
        
        IOptionsService CreateOptionsService(string connection);

    }
}
