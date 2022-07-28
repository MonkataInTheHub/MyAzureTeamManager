using Microsoft.EntityFrameworkCore;
using MyAzureTeamManager.Models;
using MyAzureTeamManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyAzureTeamManager.Tests.BoardServiceUnitTests
{
    public class UpdateBoardShould
    {
        [Fact]
        public async System.Threading.Tasks.Task UpdateBoardShouldSucceed()
        {
            //Arrange
            var dbContext = new MyAzureTeamManagerDbContext(Utils.GetOptions("UpdateBoardDb"));
            Utils.Seed(dbContext);
            var sut = new BoardService(dbContext);
            var id = 1;
            var board = new Board(1);

            //Act
            await sut.UpdateAsync(id, board);
            var result = await dbContext.Boards.FirstOrDefaultAsync(x => x.BoardId == id);

            //Assert
            Assert.Equal(board.Bugs, result.Bugs);
            Assert.Equal(board.Tasks, result.Tasks);
            Assert.Equal(board.Feedbacks, result.Feedbacks);
        }
    }
}
