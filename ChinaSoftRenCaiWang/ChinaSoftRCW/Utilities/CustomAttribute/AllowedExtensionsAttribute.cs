using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChinaSoftRCW.Utilities.CustomAttribute
{
    public class AllowedExtensionsAttribute: ValidationAttribute
    {
        private readonly string[] allowedExtensions;
        public AllowedExtensionsAttribute(string[] allowedDomains)
        {
            this.allowedExtensions = allowedDomains;
        }

        public override bool IsValid(object value)
        {
            var domain = value.ToString().Split('@').Last().ToLower();
            return allowedExtensions.Contains(domain);
        }
    }
}
