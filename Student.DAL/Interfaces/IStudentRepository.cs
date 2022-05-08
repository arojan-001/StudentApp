using Student.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DAL.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Students> GetStudents();
        IEnumerable<ExamResult> GetExamResult();
        ExamResult GetExamResultById(int id);
        ExamResult GetExamResultByStudId(string id);
        Students GetById(string id);
        void SaveStudents(Students product, bool isSaveChanges = true);
        void SaveExamResult(ExamResult product, bool isSaveChanges = true);
        Students DeleteStudents(string productId, bool isSaveChanges = true);
        ExamResult DeleteStudents(int id, bool isSaveChanges = true);
        void SaveChanges();
    }
}
