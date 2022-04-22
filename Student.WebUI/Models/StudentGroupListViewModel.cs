using Student.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Student.WebUI.Models
{
    public class StudentGroupListViewModel
    {
        public List<StudentGroupDTO> StudentGroupList { get; set; }
    }
}