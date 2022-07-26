using Microsoft.EntityFrameworkCore;
using MyAzureTeamManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyAzureTeamManager.Models.Interfaces;


namespace MyAzureTeamManager.Services
{
    public class BoardService : IBoardService
    {
        readonly MyAzureTeamManagerDbContext _dbContext;

        public BoardService(MyAzureTeamManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Board>> GetAllBoardsAsync()
        {
            return await _dbContext.Boards.ToListAsync();
        }
        public async Task<Board> GetAsync(int boardId)
        {
            return await _dbContext.Boards
                .FirstOrDefaultAsync(x => x.BoardId == boardId);
        }

        public void Create(Board board)
        {
            _dbContext.Boards.Add(board);
            _dbContext.SaveChanges();
        }
        public async System.Threading.Tasks.Task UpdateAsync(int id, Board boardProvided)
        {
            var Board = await _dbContext.Boards
                .FirstOrDefaultAsync(x => x.BoardId == id);
            if (Board is null)
            {
                throw new Exception("Board does not exist!");
            }

            Board.Bugs = boardProvided.Bugs;
            Board.Tasks = boardProvided.Tasks;
            Board.Feedbacks = boardProvided.Feedbacks;
            _dbContext.SaveChanges();
        }

        public async Task<bool> DeleteAsync(int boardId)
        {
            var board = await _dbContext.Boards
                .FirstOrDefaultAsync(x => x.BoardId == boardId);
            if (board != null)
            {
                _dbContext.Boards.Remove(board);
                _dbContext.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
