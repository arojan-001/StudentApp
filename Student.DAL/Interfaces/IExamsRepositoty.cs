using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.DAL.Entities;

namespace Student.DAL.Interfaces
{
    public interface IExamsRepositoty
    {
        IEnumerable<Exams> GetExams();

        Exams GetById(int id);

        void SaveExam(Exams product, bool isSaveChanges = true);

        Exams DeleteExam(int productId, bool isSaveChanges = true);

        void SaveChanges();
    }
}
