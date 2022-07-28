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
            var teams = await _dbContext.Teams.ToListAsync();

            foreach (var team in teams)
            {
                var members = await _dbContext.People.Where(x => x.TeamId == team.TeamId).ToListAsync();
                var boards = await _dbContext.Boards.Where(x => x.TeamId == team.TeamId).ToListAsync();
                foreach (var board in boards)
                {
                    team.Boards.Add(board);
                }
                foreach (var member in members)
                {
                    team.Members.Add(member);
                }
            }
            return await _dbContext.Teams.ToListAsync();
        }
        public async Task<Team> GetAsync(int teamId)
        {
            var team = await _dbContext.Teams
                .FirstOrDefaultAsync(x => x.TeamId == teamId);
            var members = await _dbContext.People.Where(x => x.TeamId == teamId).ToListAsync();
            var boards = await _dbContext.Boards.Where(x => x.TeamId == teamId).ToListAsync();
            if (members is null)
            {
                throw new Exception("Team does not exist!");
            }
            if (boards is null)
            {
                throw new Exception("Person does not exist!");
            }
            foreach (var board in boards)
            {
                team.Boards.Add(board);
            }
            foreach (var member in members)
            {
                team.Members.Add(member);
            }
            return team;
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
                throw new Exception("Team does not exist!");
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
        public async System.Threading.Tasks.Task AssignPersonToTeamAsync(int personId)
        {
            var person = await _dbContext.People.FirstOrDefaultAsync(x => x.PersonId == personId);
            var team = await _dbContext.Teams.FirstOrDefaultAsync(x => x.TeamId == person.TeamId);
            if (team is null)
            {
                throw new Exception("Team does not exist!");
            }
            if (person is null)
            {
                throw new Exception("Person does not exist!");
            }
            team.Members.Add(person);
            _dbContext.SaveChanges();
        }
        public async System.Threading.Tasks.Task AssignBoardToTeamAsync(int boardId)
        {
            var board = await _dbContext.Boards.FirstOrDefaultAsync(x => x.BoardId == boardId);
            var team = await _dbContext.Teams.FirstOrDefaultAsync(x => x.TeamId == board.TeamId);
            if (team is null)
            {
                throw new Exception("Team does not exist!");
            }
            team.Boards.Add(board);
            _dbContext.SaveChanges();
        }
    }
}
