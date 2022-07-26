using Microsoft.EntityFrameworkCore;
using MyAzureTeamManager.Models;
using MyAzureTeamManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyAzureTeamManager.Tests.TeamServiceUnitTests
{
    public class UpdateTeamShould
    {
        [Fact]
        public async System.Threading.Tasks.Task UpdateTeamShouldSucceed()
        {
            //Arrange
            var dbContext = new MyAzureTeamManagerDbContext(Utils.GetOptions("UpdateTeamDb"));
            Utils.Seed(dbContext);
            var sut = new TeamService(dbContext);
            var id = 1;
            var team = new Team
            {
                TeamName = "Misho",
            };

            //Act
            await sut.UpdateAsync(id, team);
            var result = await dbContext.Teams.FirstOrDefaultAsync(x => x.TeamId == id);

            //Assert
            Assert.Equal(team.TeamName, result.TeamName);
        }
    }
}
