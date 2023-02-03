using MyAzureTeamManager.Models;
using MyAzureTeamManager.Models.Interfaces;

namespace MyAzureTeamManager.Services
{
    public interface IPersonService
    {
        void Create(Person Person);
        Task<bool> DeleteAsync(int personId);
        Task<List<Person>> GetAllPeopleAsync();
        Task<Person> GetAsync(int personId);
        Task<List<IWorkItem>> GetPersonActivityAsync(int personId);
        System.Threading.Tasks.Task UpdateAsync(int id, Person PersonProvided);
    }
}