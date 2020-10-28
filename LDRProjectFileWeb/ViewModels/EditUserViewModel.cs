using LDRProjectFileWeb.CustomerUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LDRProjectFileWeb.ViewModels
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            Claims = new List<string>();
            Roles = new List<string>();
        }


        public string Id { get; set; }
        [Required]
        public string UserName { get; set;}

        [Required]
        [EmailAddress]
        [ValidEmailDomain(allowedDomain: "js-leader.com", ErrorMessage = "电子邮件后缀必须是js-leader.com")]
        public string Email { get; set; }

        public  IList<string> Roles{ get; set; }

        public List<string> Claims { get; set; }

        public string City { get; set; }
    }
}
