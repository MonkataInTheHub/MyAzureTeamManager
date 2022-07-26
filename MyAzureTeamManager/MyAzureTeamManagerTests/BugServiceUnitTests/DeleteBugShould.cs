using MyAzureTeamManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyAzureTeamManager.Tests.BugServiceUnitTests
{
    public class DeleteBugShould
    {
        [Fact]
        public async Task DeleteBugShouldSucceed()
        {
            //Arrange
            const int bugId = 3;
            var dbContext = new MyAzureTeamManagerDbContext(Utils.GetOptions("DeleteBugDb"));
            Utils.Seed(dbContext);
            var sut = new BugService(dbContext);

            //Act
            var result = await sut.DeleteAsync(bugId);

            //Assert
            Assert.True(result);
            Assert.True(dbContext.Bugs.FirstOrDefault(x => x.BugId == bugId) == null);
        }
    }
}
