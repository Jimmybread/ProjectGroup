using ChinaSoftRCW.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChinaSoftRCW.ViewModels
{
    public class CandidateVM
    {

        [Display(Name = "姓名")]
        [MaxLength(20)]
        [Required(ErrorMessage = "必填")]
        public string FullName { get; set; }

        [Display(Name = "年龄")]
        [RegularExpression(@"^([1-9]\d?|1[01]\d|120)$", ErrorMessage = "1-120岁")]
        public int? Age { get; set; }

        [Display(Name = "职位")]
        [Required(ErrorMessage = "必填")]
        [MaxLength(100)]
        public string Position { get; set; }

        [Display(Name = "经验")]
        [RegularExpression(@"^[0-9]{1,2}$")]
        [Required(ErrorMessage = "必填")]
        public int? Experience { get; set; }

        [Display(Name = "号码")]
        [RegularExpression(@"^[0-9]{7,11}$", ErrorMessage = "请输入正确的号码")]
        [Required(ErrorMessage = "必填")]
        public string Phone { get; set; }

        [Display(Name = "邮箱")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "请输入正确的邮箱")]
        [MaxLength(100)]
        public string Email { get; set; }

        [Display(Name = "现居住地址")]
        [Required(ErrorMessage = "必填")]
        [MaxLength(200)]
        public string ResidentAddress { get; set; }

        [Display(Name = "性别")]
        public int? GenderId { get; set; }

        [Display(Name = "工作状态")]
        [Required(ErrorMessage = "必填")]
        public int? JobStateId { get; set; }

        [Display(Name = "技术")]
        [Required(ErrorMessage = "必填")]
        public int? TechStackId { get; set; }

        [Display(Name = "项目")]
        [Required(ErrorMessage = "必填")]
        public int? ProjectId { get; set; }

        [Display(Name = "上传文件")]
        public IFormFile Resume { get; set; }
    }
}
