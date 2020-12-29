using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChinaSoftRCW.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("Name")]
        public string ProjectName { get; set; }

        public IEnumerable<Candidate> Candidates { get; set; }
    }
}
