using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChinaSoftRCW.ViewModels
{
    public class LoginViewModel
    {   
        [Display(Name ="邮箱")]
        [Required(ErrorMessage = "邮箱不能为空")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "密码")]
        [Required(ErrorMessage ="密码不能为空")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "记住密码")]
        public bool RememberMe { get; set; }
    }
}
