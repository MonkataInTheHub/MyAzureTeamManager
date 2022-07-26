using MyAzureTeamManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyAzureTeamManager.Tests.TeamServiceUnitTests
{
    public class DeleteTeamShould
    {
        [Fact]
        public async Task DeleteTeamShouldSucceed()
        {
            //Arrange
            const int teamId = 3;
            var dbContext = new MyAzureTeamManagerDbContext(Utils.GetOptions("DeleteTeamDb"));
            Utils.Seed(dbContext);
            var sut = new TeamService(dbContext);

            //Act
            var result = await sut.DeleteAsync(teamId);

            //Assert
            Assert.True(result);
            Assert.True(dbContext.Teams.FirstOrDefault(x => x.TeamId == teamId) == null);
        }
    }
}
