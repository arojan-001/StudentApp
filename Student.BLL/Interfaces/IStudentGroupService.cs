using Student.BLL.DTO;
using Student.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.BLL.Interfaces
{
    public interface IStudentGroupService : IDisposable
    {
        OperationDetails Create(StudentGroupDTO groupDto);
        List<StudentGroupDTO> GetAll();

        StudentGroupDTO Delete(int id);

        StudentGroupDTO GetById(int id);
    }
}
