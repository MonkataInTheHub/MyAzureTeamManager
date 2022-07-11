using Microsoft.AspNetCore.Mvc;
using MyAzureTeamManager.Models;
using MyAzureTeamManager.Models.Interfaces;
using MyAzureTeamManager.Services;

namespace MyAzureTeamManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BugController : ControllerBase
    {
        readonly IBugService _bugService;
        public BugController(IBugService bugService)
        {
            _bugService = bugService;
        }

        [HttpGet("GetAllBugs")]
        public async Task<IEnumerable<Bug>> GetAllBugs()
        {
            return await _bugService.GetAllBugsAsync();
        }

        [HttpGet("GetBug")]
        public async Task<IBug> Get(int bugId)
        {
            return await _bugService.GetAsync(bugId);
        }

        [HttpPost]
        public void Create([FromBody] Bug bug)
        {
            _bugService.Create(bug);
        }

        [HttpPut]
        public async System.Threading.Tasks.Task Update([FromBody] Bug bug)
        {
            await _bugService.UpdateAsync(bug);
        }

        [HttpDelete]
        public void Delete([FromBody] int bugId)
        {
            _bugService.DeleteAsync(bugId);
        }
    }
}
