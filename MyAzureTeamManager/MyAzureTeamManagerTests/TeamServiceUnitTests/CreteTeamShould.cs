using Microsoft.EntityFrameworkCore;
using MyAzureTeamManager;
using MyAzureTeamManager.Models;
using MyAzureTeamManager.Services;
using MyAzureTeamManager.Tests;
using System.Linq;
using Xunit;

namespace MyAzureTeamManagerTests
{
    public class CreateTeamShould
    {
        [Fact]
        public void CreateTeamShouldSucceed()
        {
            //Arrange
            var dbContext = new MyAzureTeamManagerDbContext(Utils.GetOptions("CreateTeamDb"));
            var sut = new TeamService(dbContext);
            var bug = new Team
            {
                TeamName = "MahlenskiqOtbor"
            };

            //Act
            sut.Create(bug);
            var result = dbContext.Teams.FirstOrDefault(p => p.TeamId == bug.TeamId);

            //Assert
            Assert.Equal(bug.TeamId, result.TeamId);
            Assert.Equal(bug.TeamName, result.TeamName);
        }
    }
}