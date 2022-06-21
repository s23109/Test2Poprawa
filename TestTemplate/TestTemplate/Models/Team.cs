using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestTemplate.Models
{
    public class Team
    {
        [Required]
        public int TeamID { get; set; }

        [Required]
        public int OrganisationID { get; set; }

        [MaxLength(50)]
        public string TeamName { get; set; }

        [MaxLength(500)]
        public string? TeamDescription { get; set; }

        public virtual Organisation Organisation { get; set; }

        public virtual IEnumerable<Membership> Membership { get; set; }

        public virtual IEnumerable<File> File { get; set; }

    }
}
