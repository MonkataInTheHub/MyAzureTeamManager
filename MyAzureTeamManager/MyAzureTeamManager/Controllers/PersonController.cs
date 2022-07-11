using Microsoft.AspNetCore.Mvc;
using MyAzureTeamManager.Models;
using MyAzureTeamManager.Models.Interfaces;
using MyAzureTeamManager.Services;

namespace MyAzureTeamManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet("GetAllPeople")]
        public async Task<IEnumerable<Person>> GetAllPeople()
        {
            return await _personService.GetAllPeopleAsync();
        }

        [HttpGet("GetPerson")]
        public async Task<IPerson> Get(int personId)
        {
            return await _personService.GetAsync(personId);
        }

        [HttpPost]
        public void Create([FromBody] Person person)
        {
            _personService.Create(person);
        }

        [HttpPut]
        public async System.Threading.Tasks.Task Update([FromBody] Person person)
        {
            await _personService.UpdateAsync(person);
        }

        [HttpDelete]
        public void Delete([FromBody] int personId)
        {
            _personService.DeleteAsync(personId);
        }
    }
}
