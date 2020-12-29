using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChinaSoftRCW.Models
{
    public class JobState
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(6)]
        [Column("Name")]
        public string JobStateName { get; set; }

        public IEnumerable<Candidate> Candidates { get; set; }
    }
}
