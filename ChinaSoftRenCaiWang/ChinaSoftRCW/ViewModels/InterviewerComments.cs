using System.ComponentModel.DataAnnotations;

namespace ChinaSoftRCW.ViewModels
{
    public class InterviewerComments
    {
        [Display(Name = "技术")]
        public string Tech { get; set; }

        [Display(Name = "语言(英语/日语/...)")]
        public string Language { get; set; }

        [Display(Name = "软技能")]
        public string SoftSkill { get; set; }

        [Display(Name = "备注")]
        public string Remark { get; set; }
    }
}