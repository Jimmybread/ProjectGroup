using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChinaSoftRCW.ViewModels
{
    public class EditCandidate : CandidateVM
    {
        public int Id { get; set; }

        [Display(Name = "简历")]
        [MaxLength(200)]
        public string ResumePath { get; set; }

        public List<SelectListItem> Genders { get; set; }

        public List<SelectListItem> JobStates { get; set; }

        public List<SelectListItem> TechStacks { get; set; }

        public List<SelectListItem> Projects { get; set; }
    }
}
