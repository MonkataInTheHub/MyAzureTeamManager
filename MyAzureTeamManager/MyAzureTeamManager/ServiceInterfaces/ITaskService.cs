
namespace MyAzureTeamManager.Services
{
    public interface ITaskService
    {
        void Create(Models.Task task);
        Task<bool> DeleteAsync(int taskId);
        Task<List<Models.Task>> GetAllTasksAsync();
        Task<Models.Task> GetAsync(int taskId);
        Task UpdateAsync(int id, Models.Task taskProvided);
    }
}