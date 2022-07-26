using Microsoft.AspNetCore.Mvc;
using MyAzureTeamManager.Models;
using MyAzureTeamManager.Models.Interfaces;
using MyAzureTeamManager.Services;

namespace MyAzureTeamManager.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        readonly IBoardService _boardService;
        public BoardController(IBoardService boardService)
        {
            _boardService = boardService;
        }

        [HttpGet("GetAllBoards")]
        public async Task<IEnumerable<Board>> GetAllBoards()
        {
            return await _boardService.GetAllBoardsAsync();
        }

        [HttpGet("GetBoard")]
        public async Task<IBoard> Get(int boardId)
        {
            return await _boardService.GetAsync(boardId);
        }

        [HttpPost]
        public void Create([FromBody] Board board)
        {
            _boardService.Create(board);
        }

        [HttpPut]
        public async System.Threading.Tasks.Task Update(int id, [FromBody] Board board)
        {
            await _boardService.UpdateAsync(id, board);
        }

        [HttpDelete]
        public void Delete([FromBody] int boardId)
        {
            _boardService.DeleteAsync(boardId);
        }
    }
}
