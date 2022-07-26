using MyAzureTeamManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyAzureTeamManager.Tests.BoardServiceUnitTests
{
    public class DeleteBoardShould
    {
        [Fact]
        public async Task DeleteBoardShouldSucceed()
        {
            //Arrange
            const int boardId = 1;
            var dbContext = new MyAzureTeamManagerDbContext(Utils.GetOptions("DeleteBoardDb"));
            Utils.Seed(dbContext);
            var sut = new BoardService(dbContext);

            //Act
            var result = await sut.DeleteAsync(boardId);

            //Assert
            Assert.True(result);
            Assert.True(dbContext.Boards.FirstOrDefault(x => x.BoardId == boardId) == null);
        }
    }
}
