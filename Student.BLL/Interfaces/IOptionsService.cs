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
    public interface IOptionsService : IDisposable
    {
        OperationDetails Create(OptionsDTO questionDTO);
        List<OptionsDTO> GetAll();
        List<OptionsDTO> GetbyQuestionid(int id);
        OptionsDTO Delete(int id);

        OptionsDTO GetById(int id);
    }
}
