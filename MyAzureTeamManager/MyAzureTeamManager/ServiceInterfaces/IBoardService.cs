using MyAzureTeamManager.Models;
using MyAzureTeamManager.Models.Interfaces;

namespace MyAzureTeamManager.Services
{
    public interface IBoardService
    {
        void Create(Board Board);
        Task<bool> DeleteAsync(int boardId);
        Task<Board> GetAsync(int boardId);
        Task<List<Board>> GetAllBoardsAsync();
        System.Threading.Tasks.Task UpdateAsync(Board BoardProvided);
    }
}