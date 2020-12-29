using Microsoft.AspNetCore.Mvc.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChinaSoftRCW.Utilities.CustomAttribute
{
    public class AllowedEmailDomainAttribute : ValidationAttribute
    {
        private readonly string[] allowedDomain;

        public AllowedEmailDomainAttribute(string[] allowedDomains)
        {
            this.allowedDomain = allowedDomains;
        }

        public override bool IsValid(object value)
        {
            var domain = value.ToString().Split('@').Last().ToLower();
            return allowedDomain.Contains(domain);
        }
    }
}
