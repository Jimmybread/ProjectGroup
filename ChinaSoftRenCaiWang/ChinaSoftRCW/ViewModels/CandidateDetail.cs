using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChinaSoftRCW.ViewModels
{
    public class CandidateDetail : CandidateVM
    {
        public int Id { get; set; }

        [Display(Name = "性别")]
        public string Gender { get; set; }

        [Display(Name = "工作状态")]
        public string JobState { get; set; }

        [Display(Name = "技术")]
        [Required(ErrorMessage = "必填")]
        public string TechStack { get; set; }

        [Display(Name = "项目")]
        [Required(ErrorMessage = "必填")]
        public string Project { get; set; }

        [Display(Name = "简历")]
        [MaxLength(200)]
        public string ResumePath { get; set; }
    }
}
