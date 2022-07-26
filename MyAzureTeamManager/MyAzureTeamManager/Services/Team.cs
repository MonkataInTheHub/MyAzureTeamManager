using Microsoft.EntityFrameworkCore;
using MyAzureTeamManager.Models;

namespace MyAzureTeamManager.Services
{
    public class TeamService : ITeamService
    {
        readonly MyAzureTeamManagerDbContext _dbContext;

        public TeamService(MyAzureTeamManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Team>> GetAllTeamsAsync()
        {
            return await _dbContext.Teams.ToListAsync();
        }
        public async Task<Team> GetAsync(int teamId)
        {
            return await _dbContext.Teams
                .FirstOrDefaultAsync(x => x.TeamId == teamId);
        }

        public void Create(Team team)
        {
            _dbContext.Teams.Add(team);
            _dbContext.SaveChanges();

        }
        public async System.Threading.Tasks.Task UpdateAsync(int id, Team teamProvided)
        {
            var team = await _dbContext.Teams
               .FirstOrDefaultAsync(x => x.TeamId == id);
            if (team is null)
            {
                throw new Exception("Person does not exist!");
            }

            team.TeamName = teamProvided.TeamName;
            _dbContext.SaveChanges();

        }

        public async Task<bool> DeleteAsync(int teamId)
        {
            var team = await _dbContext.Teams
                .FirstOrDefaultAsync(x => x.TeamId == teamId);
            if (team != null)
            {
                _dbContext.Teams.Remove(team);
                _dbContext.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
