using Student.BLL.DTO;
using Student.BLL.Infrastructure;
using Student.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.BLL.Interfaces
{
    public interface ILessonService : IDisposable
    {
        OperationDetails Create(LessonDTO lessonDto);
        List<LessonDTO> GetAll();

        LessonDTO Delete(int id);

        LessonDTO GetById(int id);
    }
}
