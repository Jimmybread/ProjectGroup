using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChinaSoftRCW.Models
{
    public class Candidate
    {
        public int Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string FullName { get; set; }

        [RegularExpression(@"^([1-9]\d?|1[01]\d|120)$", ErrorMessage = "1-120岁")]
        public int? Age { get; set; }

        [Required]
        [MaxLength(100)]
        public string Position { get; set; }

      
        [RegularExpression(@"^[0-9]{1,2}$")]
        [Required]
        public int? Experience { get; set; }

        [RegularExpression(@"^[0-9]{7,11}$", ErrorMessage = "请输入正确的号码")]
        [Required]
        [Column(TypeName = "varchar(11)")]
        public string Phone { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "请输入正确的邮箱")]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(200)]
        public string ResidentAddress { get; set; }

        [MaxLength(200)]
        public string ResumePath { get; set; }

        [ForeignKey("Gender")]
        public int? GenderId { get; set; }

        [Required]
        [ForeignKey("JobState")]
        public int? JobStateId { get; set; }

        [Required]
        [ForeignKey("TechStack")]
        public int? TechStackId { get; set; }

        [Required]
        [ForeignKey("Project")]
        public int? ProjectId { get; set; }

        public Gender Gender { get; set; }

        public JobState JobState { get; set; }

        public TechStack TechStack { get; set; }

        public Project Project { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
    }
}
