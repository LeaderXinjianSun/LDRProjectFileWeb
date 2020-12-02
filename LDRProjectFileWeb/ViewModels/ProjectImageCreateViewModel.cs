using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LDRProjectFileWeb.ViewModels
{
    public class ProjectImageCreateViewModel
    {
        [Display(Name = "文件")]
        public IFormFile File { get; set; }
    }
}
