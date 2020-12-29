using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChinaSoftRCW.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required]
        [Display(Name = "邮箱地址")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("Password",
            ErrorMessage = "密码和确认密码必须一致")]
        public string ConfirmPassword { get; set; }
    }
}
