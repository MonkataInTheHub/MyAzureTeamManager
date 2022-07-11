using Microsoft.EntityFrameworkCore;
using MyAzureTeamManager.Models;

namespace MyAzureTeamManager.Services
{
    public class TaskService : ITaskService
    {
        readonly MyAzureTeamManagerDbContext _dbContext;

        public TaskService(MyAzureTeamManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Models.Task>> GetAllTasksAsync()
        {
            return await _dbContext.Tasks.ToListAsync();
        }
        public async Task<Models.Task> GetAsync(int taskId)
        {
            return await _dbContext.Tasks
                .FirstOrDefaultAsync(x => x.TaskId == taskId);
        }
        public void Create(Models.Task task)
        {
            _dbContext.Tasks.Add(task);
            _dbContext.SaveChanges();
        }
        public async System.Threading.Tasks.Task UpdateAsync(Models.Task taskProvided)
        {
            var Task = await _dbContext.Tasks
                .FirstOrDefaultAsync(x => x.TaskId == taskProvided.TaskId);
            if (Task is null)
            {
                throw new Exception("Task does not exist!");
            }

            Task.TaskId = taskProvided.TaskId;
            Task.Title = taskProvided.Title;
            Task.Description = taskProvided.Description;
            Task.Comments = taskProvided.Comments;
            Task.History = taskProvided.History;
            Task.BoardId = taskProvided.BoardId;
            Task.Priority = taskProvided.Priority;
            Task.TaskStatus = taskProvided.TaskStatus;
            _dbContext.SaveChanges();
        }
        public async Task<bool> DeleteAsync(int taskId)
        {
            var task = await _dbContext.Tasks
                .FirstOrDefaultAsync(x => x.TaskId == taskId);
            if (task != null)
            {
                _dbContext.Tasks.Remove(task);
                _dbContext.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
