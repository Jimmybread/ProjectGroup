using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChinaSoftRCW.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [ForeignKey("Candidate")]
        public int CandidateId { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }

        [MaxLength(2000)]
        public string Text { get; set; }

        public Candidate Candidate { get; set; }

        public Role Role { get; set; }
    }
}
