using MyAzureTeamManager.Models;

namespace MyAzureTeamManager.Services
{
    public interface IBugService
    {
        void Create(Bug Bug);
        Task<bool> DeleteAsync(int bugId);
        Task<List<Bug>> GetAllBugsAsync();
        Task<Bug> GetAsync(int bugId);
        System.Threading.Tasks.Task UpdateAsync(Bug BugProvided);
    }
}