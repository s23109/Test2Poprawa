using System.Threading.Tasks;
using TestTemplate.DTO;

namespace TestTemplate.Services
{
    public interface IDBService
    {

        Task<bool> DoesTeamExist(int idTeam);

        Task<TeamDTO> GetTeam(int idTeam);

    }
}
