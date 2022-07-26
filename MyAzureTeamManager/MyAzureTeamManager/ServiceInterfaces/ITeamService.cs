using MyAzureTeamManager.Models;

namespace MyAzureTeamManager.Services
{
    public interface ITeamService
    {
        void Create(Team team);
        Task<bool> DeleteAsync(int teamId);
        Task<List<Team>> GetAllTeamsAsync();
        Task<Team> GetAsync(int teamId);
        System.Threading.Tasks.Task UpdateAsync(int id, Team teamProvided);
    }
}