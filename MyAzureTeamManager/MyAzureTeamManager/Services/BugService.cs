using Microsoft.EntityFrameworkCore;
using MyAzureTeamManager.Models;
using MyAzureTeamManager.Models.Interfaces;

namespace MyAzureTeamManager.Services
{
    public class BugService : IBugService
    {
        readonly MyAzureTeamManagerDbContext _dbContext;

        public BugService(MyAzureTeamManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Bug>> GetAllBugsAsync()
        {
            return await _dbContext.Bugs.ToListAsync();
        }
        public async Task<Bug> GetAsync(int bugId)
        {
            return await _dbContext.Bugs
                .FirstOrDefaultAsync(x => x.BugId == bugId);
        }
        public void Create(Bug bug)
        {
            _dbContext.Bugs.Add(bug);
            _dbContext.SaveChanges();
        }
        public async System.Threading.Tasks.Task UpdateAsync(Bug bugProvided)
        {
            var Bug = await _dbContext.Bugs
                .FirstOrDefaultAsync(x => x.BugId == bugProvided.BugId);
            if (Bug is null)
            {
                throw new Exception("Bug does not exist!");
            }

            Bug.BugId = bugProvided.BugId;
            Bug.Title = bugProvided.Title;
            Bug.Description = bugProvided.Description;
            Bug.Comments = bugProvided.Comments;
            Bug.History = bugProvided.History;
            Bug.BoardId = bugProvided.BoardId;
            Bug.Priority = bugProvided.Priority;
            Bug.Severity = bugProvided.Severity;
            Bug.BugStatus = bugProvided.BugStatus;
            _dbContext.SaveChanges();
        }
        public async Task<bool> DeleteAsync(int bugId)
        {
            var bug = await _dbContext.Bugs
                .FirstOrDefaultAsync(x => x.BugId == bugId);
            if (bug != null)
            {
                _dbContext.Bugs.Remove(bug);
                _dbContext.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
