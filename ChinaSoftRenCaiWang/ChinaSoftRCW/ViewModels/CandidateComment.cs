using ChinaSoftRCW.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChinaSoftRCW.ViewModels
{
    public class CandidateComment : CandidateDetail
    {
        public CandidateComment()
        {
            InterviewComments = new InterviewComments();
        }

        [Display(Name = "面试备注")]
        public InterviewComments InterviewComments { get; set; }
    }
}
