using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LDRProjectFileWeb.ViewModels
{
    public class DocumentCreateViewModel
    {
        [Display(Name = "文件")]
        public List<IFormFile> Files { get; set; }
        [Required]
        public string ProjectID { get; set; }
    }
}
