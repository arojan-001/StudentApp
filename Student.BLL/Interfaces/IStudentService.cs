using Student.BLL.DTO;
using Student.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.BLL.Interfaces
{
    public interface IStudentService : IDisposable
    {
        OperationDetails Create(StudentDTO studentDto);
        List<StudentDTO> GetAll();

        StudentDTO Delete(string id);

        StudentDTO GetById(string id);
    }
}
