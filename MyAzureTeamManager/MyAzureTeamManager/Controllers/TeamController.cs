using Microsoft.AspNetCore.Mvc;
using MyAzureTeamManager.Models;
using MyAzureTeamManager.Models.Interfaces;
using MyAzureTeamManager.Services;

namespace MyAzureTeamManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        readonly ITeamService _teamService;
        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet("GetAllTeams")]
        public async Task<IEnumerable<Team>> GetAllTeams()
        {
            return await _teamService.GetAllTeamsAsync();
        }

        [HttpGet("GetTeam")]
        public async Task<ITeam> Get(int teamId)
        {
            return await _teamService.GetAsync(teamId);
        }

        [HttpPost]
        public void Create([FromBody] Team team)
        {
            _teamService.Create(team);
        }

        [HttpPut]
        public async System.Threading.Tasks.Task Update([FromBody] Team team)
        {
            await _teamService.UpdateAsync(team);
        }

        [HttpDelete]
        public void Delete([FromBody] int teamId)
        {
            _teamService.DeleteAsync(teamId);
        }
    }
}
