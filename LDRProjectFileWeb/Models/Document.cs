using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LDRProjectFileWeb.Models
{
    public class Document
    {
        public int Id { get; set; }
        [Required]
        public string ProjectID { get; set; }
        [Required]
        [Display(Name = "上传时间")]
        public DateTime UploadDate { get; set; }
        [Required]
        [Display(Name = "上传人")]
        public string Uploader { get; set; }

    }
}
