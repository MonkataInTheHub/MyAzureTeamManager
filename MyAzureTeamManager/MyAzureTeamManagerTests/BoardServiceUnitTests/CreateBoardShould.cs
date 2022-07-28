using Microsoft.EntityFrameworkCore;
using MyAzureTeamManager;
using MyAzureTeamManager.Models;
using MyAzureTeamManager.Services;
using MyAzureTeamManager.Tests;
using System.Linq;
using Xunit;

namespace MyAzureTeamManagerTests.Tests.BoardServiceUnitTests
{
    public class CreateBoardShould
    {
        [Fact]
        public void CreateBoardShouldSucceed()
        {
            //Arrange
            var dbContext = new MyAzureTeamManagerDbContext(Utils.GetOptions("CreateBoardDb"));
            var sut = new BoardService(dbContext);
            var board = new Board(1);
            

            //Act
            sut.Create(board);
            var result = dbContext.Boards.FirstOrDefault(p => p.BoardId == board.BoardId);

            //Assert
            Assert.Equal(board.BoardId, result.BoardId);
            Assert.Equal(board.Bugs, result.Bugs);
            Assert.Equal(board.Tasks, result.Tasks);
            Assert.Equal(board.Feedbacks, result.Feedbacks);

        }
    }
}