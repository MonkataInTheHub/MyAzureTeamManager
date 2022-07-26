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
    public class GetBoardShould
    {
        [Fact]
        public async Task GetBoardShouldSucceed()
        {
            //Arrange
            var dbContext = new MyAzureTeamManagerDbContext(Utils.GetOptions($"{Guid.NewGuid()}"));
            Utils.Seed(dbContext);
            var sut = new BoardService(dbContext);
            var id = 1;
            var expected = await dbContext.Boards
                .FirstOrDefaultAsync(p => p.BoardId == id);

            //Act
            var result = await sut.GetAsync(id);

            //Assert
            Assert.Equal(expected.BoardId, result.BoardId);
            Assert.Equal(expected.Bugs, result.Bugs);
            Assert.Equal(expected.Tasks, result.Tasks);
            Assert.Equal(expected.Feedbacks, result.Feedbacks);
        }
    }
}
