using System.Collections.Generic;

namespace TestTemplate.DTO
{
    public class TeamDTO
    {

        public string Name { get; set; }

        public string OrganisationName { get; set; }

        public string Description { get; set; }

        public List<MemberDTO> Members { get; set; }



    }
}
