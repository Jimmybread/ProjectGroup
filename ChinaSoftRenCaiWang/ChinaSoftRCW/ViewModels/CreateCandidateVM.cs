using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChinaSoftRCW.ViewModels
{
    public class CreateCandidateVM : CandidateVM
    {
        public List<SelectListItem> Genders { get; set; }

        public List<SelectListItem> JobStates { get; set; }

        public List<SelectListItem> TechStacks { get; set; }

        public List<SelectListItem> Projects { get; set; }
    }
}
