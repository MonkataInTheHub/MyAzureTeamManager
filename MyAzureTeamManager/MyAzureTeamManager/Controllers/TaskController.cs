using Microsoft.AspNetCore.Mvc;
using MyAzureTeamManager.Models.Interfaces;
using MyAzureTeamManager.Services;

namespace MyAzureTeamManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("GetAllTasks")]
        public async Task<IEnumerable<Models.Task>> GetAllTasks()
        {
            return await _taskService.GetAllTasksAsync();
        }

        [HttpGet("GetTask")]
        public async Task<ITask> Get(int taskId)
        {
            return await _taskService.GetAsync(taskId);
        }

        [HttpPost]
        public void Create([FromBody] Models.Task task)
        {
            _taskService.Create(task);
        }

        [HttpPut]
        public async System.Threading.Tasks.Task Update(int id, [FromBody] Models.Task task)
        {
            await _taskService.UpdateAsync(id, task);
        }

        [HttpDelete]
        public void Delete([FromBody] int taskId)
        {
            _taskService.DeleteAsync(taskId);
        }
    }
}
