using Microsoft.EntityFrameworkCore;
using MyAzureTeamManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyAzureTeamManager.Tests.BoardServiceUnitTests
{
    public class GetAllBoardsShould
    {
        [Fact]
        public async Task GetAllBoardsShouldSucceed()
        {
            //Arrange
            var dbContext = new MyAzureTeamManagerDbContext(Utils.GetOptions("GetAllBoardsDb"));
            Utils.Seed(dbContext);
            var sut = new BoardService(dbContext);

            //Act
            var result = await sut.GetAllBoardsAsync();

            //Assert
            Assert.Equal(String.Join(" ", await dbContext.Boards.ToListAsync()), String.Join(" ", result));

        }
    }
}
