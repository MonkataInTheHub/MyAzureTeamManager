using Microsoft.EntityFrameworkCore;
using MyAzureTeamManager.Models;
using MyAzureTeamManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyAzureTeamManager.Tests.BugServiceUnitTests
{
    public class UpdateBugShould
    {
        [Fact]
        public async System.Threading.Tasks.Task UpdateBugShouldSucceed()
        {
            //Arrange
            var dbContext = new MyAzureTeamManagerDbContext(Utils.GetOptions("UpdateBugDb"));
            Utils.Seed(dbContext);
            var sut = new BugService(dbContext);
            var id = 1;
            var bug = new Bug
            {
                Title = "problem",
                Description = "nqkyde",
                BugStatus = Status.Completed,
                History = "",
                BoardId = 2,
                Priority = Priority.Low
            };

            //Act
            await sut.UpdateAsync(id, bug);
            var result = await dbContext.Bugs.FirstOrDefaultAsync(x => x.BugId == id);

            //Assert

            Assert.Equal(bug.Title, result.Title);
            Assert.Equal(bug.Description, result.Description);
            Assert.Equal(bug.BugStatus, result.BugStatus);
            Assert.Equal(bug.History, result.History);
            Assert.Equal(bug.BoardId, result.BoardId);
            Assert.Equal(bug.Priority, result.Priority);
            Assert.Equal(bug.Severity, result.Severity);
        }
    }
}
