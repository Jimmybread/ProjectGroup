using System.ComponentModel.DataAnnotations;

namespace ChinaSoftRCW.ViewModels
{
    public class InterviewComments
    {
        public InterviewComments()
        {
            InterviewerComments = new InterviewerComments();
        }

        [Display(Name = "HR的备注")]
        public string HRComment { get; set; }

        [Display(Name = "面试官的备注")]
        public InterviewerComments InterviewerComments { get; set; }

        [Display(Name = "PM的备注")]
        public string PMComment { get; set; }

        [Display(Name = "客户的备注")]
        public string ClientComment { get; set; }
    }
}