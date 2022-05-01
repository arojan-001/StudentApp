using Student.BLL.DTO;
using Student.BLL.Infrastructure;
using Student.BLL.Interfaces;
using Student.DAL.Entities;
using Student.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.BLL.Services
{
    public class StudentService : IStudentService
    {
        IStudentRepository Database { get; set; }

        public StudentService(IStudentRepository sg)
        {
            Database = sg;
        }

        public OperationDetails Create(StudentDTO studentDto)
        {
            Students stud = Database.GetById(studentDto.StudentId);
            if (stud == null)
            {
                stud = new Students { Id = studentDto.StudentId, GroupId = studentDto.Groupid };
                Database.SaveStudents(stud);
                return new OperationDetails(true, "Success ", "");
            }
            else
            {
                Database.SaveStudents(new Students() { Id = studentDto.StudentId, GroupId = studentDto.Groupid });
                return new OperationDetails(true, "Success ", "");
            }
        }

        public List<StudentDTO> GetAll()
        {
            var students = Database.GetStudents();
            List<StudentDTO> studentDTO = new List<StudentDTO>();
            foreach (var item in students)
            {
                studentDTO.Add(new StudentDTO() { StudentId = item.Id, Groupid = item.GroupId });
            }
            return studentDTO;
        }

        public StudentDTO Delete(string id)
        {
            var dt = Database.DeleteStudents(id);

            return new StudentDTO() { StudentId = dt.Id, Groupid = dt.GroupId };
        }
        public StudentDTO GetById(string id)
        {
            var dt = Database.GetById(id);

            return new StudentDTO() { StudentId = dt.Id, Groupid = dt.GroupId };
        }


        public void Dispose()
        {
            return;
        }
    }
}
