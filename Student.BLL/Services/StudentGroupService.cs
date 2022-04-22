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
    public class StudentGroupService : IStudentGroupService
    {
        IStudentGroupRepository Database { get; set; }

        public StudentGroupService(IStudentGroupRepository sg)
        {
            Database = sg;
        }

        public OperationDetails Create(StudentGroupDTO groupDto)
        {
            StudentGroup group = Database.GetById(groupDto.Id);
            if (group == null)
            {
                group = new StudentGroup { Id = groupDto.Id, Name = groupDto.Name };
                Database.SaveStudentGroup(group);
                return new OperationDetails(true, "Success ", "");
            }
            else
            {
                Database.SaveStudentGroup(new StudentGroup() { Id = groupDto.Id, Name = groupDto.Name });
                return new OperationDetails(true, "Success ", "");
            }
        }

        public List<StudentGroupDTO> GetAll()
        {
            var groups = Database.GetStudentGroups();
            List<StudentGroupDTO> groupsDTO = new List<StudentGroupDTO>();
            foreach (var item in groups)
            {
                groupsDTO.Add(new StudentGroupDTO() { Id = item.Id, Name = item.Name });
            }
            return groupsDTO;
        }

        public StudentGroupDTO Delete(int id)
        {
            var dt = Database.DeleteStudentGroup(id);

            return new StudentGroupDTO() { Id = dt.Id, Name = dt.Name };
        }
        public StudentGroupDTO GetById(int id)
        {
            var dt = Database.GetById(id);

            return new StudentGroupDTO() { Id = dt.Id, Name = dt.Name };
        }


        public void Dispose()
        {
            return;
        }
    }
}
