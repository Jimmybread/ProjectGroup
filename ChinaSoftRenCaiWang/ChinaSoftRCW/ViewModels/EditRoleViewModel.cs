using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChinaSoftRCW.ViewModels
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            Users = new List<string>();
        }

        [Display(Name = "角色Id")]
        public string Id { get; set; }

        [Required(ErrorMessage = "请输入角色")]
        [Display(Name = "角色")]
        [MaxLength(20)]
        public string RoleName { get; set; }

        public List<string> Users { get; set; }
    }
}
