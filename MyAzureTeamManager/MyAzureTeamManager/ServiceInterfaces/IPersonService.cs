using MyAzureTeamManager.Models;

namespace MyAzureTeamManager.Services
{
    public interface IPersonService
    {
        void Create(Person Person);
        Task<bool> DeleteAsync(int personId);
        Task<List<Person>> GetAllPeopleAsync();
        Task<Person> GetAsync(int personId);
        System.Threading.Tasks.Task UpdateAsync(Person PersonProvided);
    }
}