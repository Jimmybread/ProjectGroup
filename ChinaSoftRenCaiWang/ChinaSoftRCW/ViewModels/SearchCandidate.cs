using ChinaSoftRCW.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChinaSoftRCW.ViewModels
{
    public class SearchCandidate
    {
        public IEnumerable<CandidateDetail> CandidateDetailList { get; set; }

        [Display(Name ="技术")]
        public int? ProjectId { get; set; }

        public IEnumerable<SelectListItem> Projects { get; set; }

        [Display(Name = "姓名")]
        public string FullName { get; set; }

        [Display(Name = "电话")]
        public string Phone { get; set; }
    }
}
