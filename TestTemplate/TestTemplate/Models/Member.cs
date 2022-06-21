using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestTemplate.Models
{
    public class Member
    {
        [Required]
        public int MemberID { get; set; }
        [Required]
        public int OrganisationID { get; set; }

        [MaxLength(20)]

        public string MemberName { get; set; }

        [MaxLength(50)]

        public string MemberSurname { get; set; }

        [MaxLength(20)]

        public string? MemberNickName { get; set; }

        public virtual Organisation Organisation { get; set; }

        public virtual IEnumerable<Membership> Membership { get; set; }


    }
}
