using ChinaSoftRCW.Utilities.CustomAttribute;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChinaSoftRCW.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "邮箱")]
        [Required(ErrorMessage = "邮箱地址必填")]
        [MaxLength(100)]
        [EmailAddress(ErrorMessage = "请输入正确的邮箱地址")]
        [Remote(action: "IsEmailUsed", controller: "Account")]
        [AllowedEmailDomain(allowedDomains: new string[] { "chinasofti.com", "chinasoftinc.com" }, ErrorMessage = "请输入中软邮箱")]
        public string Email { get; set; }

        [Display(Name = "密码")]
        [Required(ErrorMessage = "密码必填")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("Password", ErrorMessage = "密码和确认密码不匹配")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "用户名")]
        [Required(ErrorMessage = "用户名不能为空")]
        [MaxLength(20, ErrorMessage = "名字过长")]
        public string WebName { get; set; }

        [Display(Name = "手机号")]
        [Required(ErrorMessage = "手机号码不能为空")]
        [Phone]
        public string Phone { get; set; }
    }
}
