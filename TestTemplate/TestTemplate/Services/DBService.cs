using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using TestTemplate.DTO;
using TestTemplate.Models;

namespace TestTemplate.Services
{
    public class DBService : IDBService
    {
        private MainDbContext dbContext;

        public DBService(MainDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

       

        public async Task<bool> DoesTeamExist(int idTeam)
        {
           var team = await dbContext.Team.Where(e => e.TeamID == idTeam).FirstOrDefaultAsync();

            if (team == null)
            {
                return false;
            }

            return true;
        }

        public async Task<TeamDTO> GetTeam(int idTeam)
        {
            var team = dbContext.Team.Where(e => e.TeamID == idTeam).FirstOrDefault();
            var membersId = dbContext.Membership.Where(e => e.TeamID == idTeam).Select(e => e.MemberID);
            var members = dbContext.Member.Where(e => membersId.Contains(e.MemberID)).Select(e => new MemberDTO
            {
                Id = e.MemberID,
                MemberName = e.MemberName,
                MemberNickName= e.MemberNickName,
                MemberSurname = e.MemberSurname
            });
            string organisationname = dbContext.Organisation.Where(e => e.OrganisationID == team.OrganisationID).Select(e => e.OrganisationName).ToList()[0];
            TeamDTO doReturna = new TeamDTO {
                Name = team.TeamName,
                Description = team.TeamDescription,
                OrganisationName = organisationname ,
                Members = (System.Collections.Generic.List<MemberDTO>)members
                
            };

            return doReturna;
        }

        public async Task<bool> ISTeamInOrganisation(int idOrganisation, int idTeam)
        {
            var Teams = dbContext.Team.Where(e => e.OrganisationID == idOrganisation).Select(e => e.TeamID);

            if (Teams.Contains(idTeam)) return true;

            return false;
        }

        public Task AddMember(MemberDTO newMember, int idOrganisation, int idTeam)
        {
            Member member = new Member
            {
                MemberID = newMember.Id,
                MemberName = newMember.MemberName,
                MemberNickName = newMember.MemberNickName,
                MemberSurname = newMember.MemberSurname,
                OrganisationID = idOrganisation
            };

            Membership membership = new Membership
            {
                MemberID = newMember.Id,
                TeamID = idTeam,
                MembershipDate = System.DateTime.Now
            };
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {

                    dbContext.Member.Add(member);

                    dbContext.Membership.Add(membership);

                    dbContext.SaveChangesAsync();

                    scope.Complete();
                }
                

            }
            catch
            {
                throw new Exception();
            }

            return Task.CompletedTask;
        }
    }
}
