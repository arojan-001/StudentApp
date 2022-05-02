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
        IEnumerable<Exam> GetExams();

        Exam GetById(int id);
        void SaveExam(Exam product, bool isSaveChanges = true);

        Exam DeleteExam(int productId, bool isSaveChanges = true);

        void SaveChanges();
    }
}
