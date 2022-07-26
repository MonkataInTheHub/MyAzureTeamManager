using Microsoft.EntityFrameworkCore;
using MyAzureTeamManager;
using MyAzureTeamManager.Models;
using MyAzureTeamManager.Services;
using MyAzureTeamManager.Tests;
using System.Linq;
using Xunit;

namespace MyAzureTeamManagerTests.Tests.BugServiceUnitTests
{
    public class CreateBugShould
    {
        [Fact]
        public void CreateBugShouldSucceed()
        {
            //Arrange
            var dbContext = new MyAzureTeamManagerDbContext(Utils.GetOptions("CreateBugDb"));
            var sut = new BugService(dbContext);
            var bug = new Bug
            {
                Title = "title",
                Description = "description",
                BoardId = 4,
                Priority = Priority.Low,
                BugStatus = Status.New,
                History = ""
            };

            //Act
            sut.Create(bug);
            var result = dbContext.Bugs.FirstOrDefault(p => p.BugId == bug.BugId);

            //Assert
            Assert.Equal(bug.BugId, result.BugId);
            Assert.Equal(bug.Title, result.Title);
            Assert.Equal(bug.Description, result.Description);
            Assert.Equal(bug.BoardId, result.BoardId);
            Assert.Equal(bug.Priority, result.Priority);
            Assert.Equal(bug.BugStatus, result.BugStatus);
        }
    }
}