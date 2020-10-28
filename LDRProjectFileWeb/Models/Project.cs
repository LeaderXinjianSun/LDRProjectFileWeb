using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LDRProjectFileWeb.Models
{
    public class Project
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "项目编号")]
        public string ProjectID { get; set; }
        [Display(Name = "项目名称")]
        public string Name { get; set; }  
        [Display(Name = "设计")]
        public string Designer { get; set; }
        [Display(Name = "电控")]
        public string Engineer { get; set; }
        [Display(Name = "软件")]
        public string Programmer { get; set; }        
    }
}
