using Microsoft.EntityFrameworkCore;
using MyAzureTeamManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyAzureTeamManager.Tests.BugServiceUnitTests
{
    public class GetAllBugsShould
    {
        [Fact]
        public async Task GetAllBugsShouldSucceed()
        {
            //Arrange
            var dbContext = new MyAzureTeamManagerDbContext(Utils.GetOptions("GetAllBugsDb"));
            Utils.Seed(dbContext);
            var sut = new BugService(dbContext);

            //Act
            var result = await sut.GetAllBugsAsync();

            //Assert
            Assert.Equal(String.Join(" ", await dbContext.Bugs.ToListAsync()), String.Join(" ", result));

        }
    }
}
