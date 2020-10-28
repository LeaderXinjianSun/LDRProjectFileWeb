using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LDRProjectFileWeb.ViewModels
{
    public class ProjectCreateViewModel
    {
        [Required(ErrorMessage = "请输入名字")]
        [Display(Name = "项目编号")]
        public string ProjectID { get; set; }
        [Display(Name = "项目名称")]
        public string Name { get; set; }       
        [Display(Name = "设计人员")]
        public string Designer { get; set; }
        [Display(Name = "电控人员")]
        public string Engineer { get; set; }
        [Display(Name = "软件人员")]
        public string Programmer { get; set; }
    }
}
