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
    public interface IExamService : IDisposable
    {
        OperationDetails Create(ExamDTO examDTO);
        List<ExamDTO> GetAll();

        ExamDTO Delete(int id);

        ExamDTO GetById(int id);
    }
}
