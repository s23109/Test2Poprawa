using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestTemplate.Models
{
    public class Organisation
    {
        [Required]
        public int OrganisationID { get; set; }

        [MaxLength(100)]
        public string OrganisationName { get; set; }

        [MaxLength(50)]
        public string OrganisationDomain { get; set; }

        public virtual IEnumerable<Team> Team { get; set; }

        public virtual IEnumerable<Member> Member { get; set; }


    }
}
