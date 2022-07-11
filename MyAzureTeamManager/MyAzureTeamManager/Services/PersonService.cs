using Microsoft.EntityFrameworkCore;
using MyAzureTeamManager.Models;

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
        public void Create(Person Person)
        {
            _dbContext.People.Add(Person);
            _dbContext.SaveChanges();
        }
        public async System.Threading.Tasks.Task UpdateAsync(Person PersonProvided)
        {
            var Person = await _dbContext.People
                .FirstOrDefaultAsync(x => x.PersonId == PersonProvided.PersonId);
            if (Person is null)
            {
                throw new Exception("Person does not exist!");
            }

            Person.PersonId = PersonProvided.PersonId;
            Person.FirstName = PersonProvided.FirstName;
            Person.LastName = PersonProvided.LastName;
            Person.Age = PersonProvided.Age;
            Person.TeamId = PersonProvided.TeamId;
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
