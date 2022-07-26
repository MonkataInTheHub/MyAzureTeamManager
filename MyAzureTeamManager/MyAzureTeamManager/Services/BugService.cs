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
        public async System.Threading.Tasks.Task UpdateAsync(int id, Bug bugProvided)
        {
            var bug = await _dbContext.Bugs
                .FirstOrDefaultAsync(x => x.BugId == id);
            if (bug is null)
            {
                throw new Exception("Bug does not exist!");
            }

            bug.Title = bugProvided.Title;
            bug.Description = bugProvided.Description;
            bug.Comments = bugProvided.Comments;
            bug.History = bugProvided.History;
            bug.BoardId = bugProvided.BoardId;
            bug.Priority = bugProvided.Priority;
            bug.Severity = bugProvided.Severity;
            bug.BugStatus = bugProvided.BugStatus;
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
