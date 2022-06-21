using System;
using System.ComponentModel.DataAnnotations;

namespace TestTemplate.Models
{
    public class Membership
    {
        [Required]
        public int? MemberID { get; set; }

        [Required]
        public int? TeamID { get; set; }

        public DateTime MembershipDate { get; set; }

        public virtual Team Team { get; set; }

        public virtual Member Member { get; set; }

    }
}
