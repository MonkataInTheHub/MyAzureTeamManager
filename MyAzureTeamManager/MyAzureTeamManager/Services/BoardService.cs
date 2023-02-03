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
            var boards = await _dbContext.Boards.ToListAsync();

            foreach (var board in boards)
            {
                var bugs = await _dbContext.Bugs.Where(x => x.BoardId == board.BoardId).ToListAsync();
                var tasks = await _dbContext.Tasks.Where(x => x.BoardId == board.BoardId).ToListAsync();
                var feedbacks = await _dbContext.Feedbacks.Where(x => x.BoardId == board.BoardId).ToListAsync();
                foreach (var bug in bugs)
                {
                    board.Bugs.Add(bug);
                }
                foreach (var task in tasks)
                {
                    board.Tasks.Add(task);
                }
                foreach (var feedback in feedbacks)
                {
                    board.Feedbacks.Add(feedback);
                }
            }
            return boards;
        }
        public async Task<Board> GetAsync(int boardId)
        {
            var board = await _dbContext.Boards
                .FirstOrDefaultAsync(x => x.BoardId == boardId);
            var bugs = await _dbContext.Bugs.Where(x => x.BoardId == boardId).ToListAsync();
            var tasks = await _dbContext.Tasks.Where(x => x.BoardId == boardId).ToListAsync();
            var feedbacks = await _dbContext.Feedbacks.Where(x => x.BoardId == boardId).ToListAsync();
            if (board is null)
            {
                throw new Exception("Board does not exist!");
            }
            foreach (var bug in bugs)
            {
                board.Bugs.Add(bug);
            }
            foreach (var task in tasks)
            {
                board.Tasks.Add(task);
            }
            foreach (var feedback in feedbacks)
            {
                board.Feedbacks.Add(feedback);
            }
            return board;
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
