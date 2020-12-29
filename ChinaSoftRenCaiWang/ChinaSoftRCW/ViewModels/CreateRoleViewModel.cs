using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChinaSoftRCW.ViewModels
{
    public class CreateRoleViewModel
    {
        [Display(Name = "角色")]
        [Required]
        [MaxLength(20)]
        public string RoleName { get; set; }
    }
}
