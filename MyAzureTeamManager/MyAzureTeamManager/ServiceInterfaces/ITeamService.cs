using MyAzureTeamManager.Models;

namespace MyAzureTeamManager.Services
{
    public interface ITeamService
    {
        void Create(Team team);
        Task<bool> DeleteAsync(int teamId);
        Task<List<Team>> GetAllTeamsAsync();
        Task<Team> GetAsync(int teamId);
        Task<List<Board>> GetTeamActivityAsync(int teamId);
        System.Threading.Tasks.Task UpdateAsync(int id, Team teamProvided);
        System.Threading.Tasks.Task AssignPersonToTeamAsync(int personId);
        System.Threading.Tasks.Task AssignBoardToTeamAsync(int boardId);
    }
}