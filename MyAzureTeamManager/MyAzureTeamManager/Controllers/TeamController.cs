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

        [HttpPut("Update")]
        public async System.Threading.Tasks.Task Update(int id, [FromBody] Team team)
        {
            await _teamService.UpdateAsync(id, team);
        }

        [HttpDelete]
        public async System.Threading.Tasks.Task Delete([FromBody] int teamId)
        {
            await _teamService.DeleteAsync(teamId);
        }
        [HttpPut("AssignPerson")]
        public async System.Threading.Tasks.Task AssignPersonToTeam(int personId)
        {
            await _teamService.AssignPersonToTeamAsync(personId);
        }
        [HttpPut("AssignBoard")]
        public async System.Threading.Tasks.Task AssignBoardToTeam(int boardId)
        {
            await _teamService.AssignBoardToTeamAsync(boardId);
        }
    }
}
