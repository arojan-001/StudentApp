using Student.BLL.Interfaces;
using Student.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.BLL.DTO;
using Student.BLL.Infrastructure;
using Student.DAL.Entities;

namespace Student.BLL.Services
{
    public class ExamService : IExamService
    {
        IExamsRepositoty Database { get; set; }

        public ExamService(IExamsRepositoty examRepository)
        {
            Database = examRepository;
        }

        public OperationDetails Create(ExamDTO examDto)
        {
            Exam exam = Database.GetById(examDto.Id);

            if (exam == null)
            {
                exam = new Exam { ExamId = examDto.Id, LessonId = examDto.LessonId, GroupId = examDto.GroupId, Duration = examDto.Duration, FullMark= examDto.FullMark, /*Created = DateTime.Now,*/ ExamDate= examDto.ExamDate };
                Database.SaveExam(exam);
                return new OperationDetails(true, "Success ", "");
            }
            else
            {
                Database.SaveExam(new Exam() { ExamId = examDto.Id, LessonId = examDto.LessonId, GroupId = examDto.GroupId, Duration = examDto.Duration, FullMark = examDto.FullMark, /*Created = DateTime.Now,*/ ExamDate = examDto.ExamDate });
                return new OperationDetails(true, "Success ", "");
            }
        }

        public List<ExamDTO> GetAll()
        {
            var exam = Database.GetExams();
            List<ExamDTO> examDTO = new List<ExamDTO>();
            foreach (var item in exam)
            {
                examDTO.Add(new ExamDTO() { Id = item.ExamId, LessonId = item.LessonId, GroupId = item.GroupId, Duration = item.Duration, FullMark = item.FullMark, /*Created = item.Created,*/ ExamDate = item.ExamDate });
            }
            return examDTO;
        }

        public ExamDTO Delete(int id)
        {
            var exam = Database.DeleteExam(id);

            return new ExamDTO() { Id = exam.ExamId, LessonId = exam.LessonId, GroupId = exam.GroupId, Duration = exam.Duration, FullMark = exam.FullMark, /*Created = exam.Created,*/ ExamDate = exam.ExamDate };
        }

        public ExamDTO GetById(int id)
        {
            var exam = Database.GetById(id);

            return new ExamDTO() { Id = exam.ExamId, LessonId = exam.LessonId, GroupId = exam.GroupId, Duration = exam.Duration, FullMark = exam.FullMark, /*Created = exam.Created,*/ ExamDate = exam.ExamDate };
        }

        public void Dispose()
        {
            return;
        }
    }
}
