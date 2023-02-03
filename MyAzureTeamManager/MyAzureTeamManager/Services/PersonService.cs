using Microsoft.EntityFrameworkCore;
using MyAzureTeamManager.Models;
using MyAzureTeamManager.Models.Interfaces;

namespace MyAzureTeamManager.Services
{
    public class PersonService : IPersonService
    {
        readonly MyAzureTeamManagerDbContext _dbContext;

        public PersonService(MyAzureTeamManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Person>> GetAllPeopleAsync()
        {
            return await _dbContext.People.ToListAsync();
        }
        public async Task<Person> GetAsync(int personId)
        {
            return await _dbContext.People
                .FirstOrDefaultAsync(x => x.PersonId == personId);
        }
        public async Task<List<IWorkItem>> GetPersonActivityAsync(int personId)
        {
            var person = await _dbContext.People
                .FirstOrDefaultAsync(x => x.PersonId == personId);
            var team = await _dbContext.Teams.FirstOrDefaultAsync(x => x.TeamId == person.TeamId);
            var boards = await _dbContext.Boards.Where(x => x.TeamId == team.TeamId).ToListAsync();
            var workItems = new List<IWorkItem>();
            foreach (var board in boards)
            {
                foreach (var bug in _dbContext.Bugs.Where(x=> x.BoardId == board.BoardId))
                {
                    workItems.Add(bug);
                }
                foreach (var task in _dbContext.Tasks.Where(x => x.BoardId == board.BoardId))
                {
                    workItems.Add(task);
                }
                foreach (var feedback in _dbContext.Feedbacks.Where(x => x.BoardId == board.BoardId))
                {
                    workItems.Add(feedback);
                }
            }
            return workItems;
        }
        public void Create(Person Person)
        {
            _dbContext.People.Add(Person);
            _dbContext.SaveChanges();
        }
        public async System.Threading.Tasks.Task UpdateAsync(int id, Person personProvided)
        {
            var person = await _dbContext.People
                .FirstOrDefaultAsync(x => x.PersonId == id);
            if (person is null)
            {
                throw new Exception("Person does not exist!");
            }

            person.FirstName = personProvided.FirstName;
            person.LastName = personProvided.LastName;
            person.Age = personProvided.Age;
            person.TeamId = personProvided.TeamId;
            _dbContext.SaveChanges();

        }
        public async Task<bool> DeleteAsync(int personId)
        {
            var person = await _dbContext.People
                .FirstOrDefaultAsync(x => x.PersonId == personId);
            if (person != null)
            {
                _dbContext.People.Remove(person);
                _dbContext.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
