using Student.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Student.WebUI.Models
{
    public class QnAnsViewModel
    {
        public int id { get; set; }
        public int examid { get; set; }
        public int mark { get; set; }
        public string question { get; set; }
        
        public List<OptionsDTO> options { get; set; }
    }
}