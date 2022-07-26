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
    public class GetBugShould
    {
        [Fact]
        public async Task GetBugShouldSucceed()
        {
            //Arrange
            var dbContext = new MyAzureTeamManagerDbContext(Utils.GetOptions($"{Guid.NewGuid()}"));
            Utils.Seed(dbContext);
            var sut = new BugService(dbContext);
            var id = 2;
            var expected = await dbContext.Bugs
                .FirstOrDefaultAsync(p => p.BugId == id);

            //Act
            var result = await sut.GetAsync(id);

            //Assert
            Assert.Equal(expected.BugId, result.BugId);
            Assert.Equal(expected.Title, result.Title);
            Assert.Equal(expected.Description, result.Description);
            Assert.Equal(expected.BugStatus, result.BugStatus);
            Assert.Equal(expected.History, result.History);
            Assert.Equal(expected.BoardId, result.BoardId);
            Assert.Equal(expected.Priority, result.Priority);
            Assert.Equal(expected.Severity, result.Severity);
        }
    }
}
