using Student.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Student.WebUI.Models
{
    public class BaseViewModel
    {
        public StudentGroupListViewModel StudentGroup { get; set; }

        public List<UserDTO> Users { get; set; }
    }
}