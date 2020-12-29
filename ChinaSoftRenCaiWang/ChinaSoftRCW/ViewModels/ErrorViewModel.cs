using System;

namespace ChinaSoftRCW.Models
{
    public class ErrorViewModel
    {
        public string ErrorTitle { get; set; }

        public string ErrorMessage { get; set; }

        private string remark;
        public string Remark
        {
            get { return string.IsNullOrWhiteSpace(remark) ? "·¢ËÍ·´À¡µ½yulin@chinasofti.com¡£" : remark; }
            set { remark = value; }
        }
    }
}
