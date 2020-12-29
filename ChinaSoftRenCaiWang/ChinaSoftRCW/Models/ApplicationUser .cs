using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChinaSoftRCW.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(20)]
        [Display(Name = "用户名")]
        public string WebName { get; set; }
    }
}
