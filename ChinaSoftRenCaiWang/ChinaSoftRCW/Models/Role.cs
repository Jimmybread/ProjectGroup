using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChinaSoftRCW.Models
{
    public class Role
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("Name")]
        public string RoleName { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
    }
}