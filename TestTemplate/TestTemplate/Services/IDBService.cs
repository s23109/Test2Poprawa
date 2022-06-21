using System.Threading.Tasks;
using TestTemplate.DTO;

namespace TestTemplate.Services
{
    public interface IDBService
    {

        Task<bool> DoesTeamExist(int idTeam);

        Task<TeamDTO> GetTeam(int idTeam);

        Task<bool> ISTeamInOrganisation( int idOrganisation , int idTeam);

        Task AddMember(MemberDTO member , int idOrganisation , int idTeam);

    }
}
