using System.ComponentModel.DataAnnotations;

namespace LDRProjectFileWeb.ViewModels
{
    public class CreateRoleViewModel
    {

        [Required]
        [Display(Name ="角色")]
        public string RoleName { get; set; }

    }
}