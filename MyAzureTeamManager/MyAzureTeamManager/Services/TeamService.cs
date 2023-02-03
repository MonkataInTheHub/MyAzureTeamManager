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
            return teams;
        }
        public async Task<Team> GetAsync(int teamId)
        {
            var team = await _dbContext.Teams.Include(x=> x.Members)
                .FirstOrDefaultAsync(x => x.TeamId == teamId);

            //var members = await _dbContext.People.Where(x => x.TeamId == teamId).ToListAsync();
            var boards = await _dbContext.Boards.Where(x => x.TeamId == teamId).ToListAsync();
            if (team is null)
            {
                throw new Exception("Team does not exist!");
            }
            foreach (var board in boards)
            {
                team.Boards.Add(board);
            }
            //foreach (var member in members)
            //{
            //    team.Members.Add(member);
            //}
            return team;
        }
        public async Task<List<Board>> GetTeamActivityAsync(int teamId)
        {
            var boards = await _dbContext.Boards.ToListAsync();

            foreach (var board in boards)
            {
                var bugs = await _dbContext.Bugs.Where(x => x.BoardId == board.BoardId).ToListAsync();
                var tasks = await _dbContext.Tasks.Where(x => x.BoardId == board.BoardId).ToListAsync();
                var feedbacks = await _dbContext.Feedbacks.Where(x => x.BoardId == board.BoardId).ToListAsync();
                foreach (var bug in bugs)
                {
                    board.Bugs.Add(bug);
                }
                foreach (var task in tasks)
                {
                    board.Tasks.Add(task);
                }
                foreach (var feedback in feedbacks)
                {
                    board.Feedbacks.Add(feedback);
                }
            }
            return boards.Where(x=> x.TeamId == teamId).ToList();
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
