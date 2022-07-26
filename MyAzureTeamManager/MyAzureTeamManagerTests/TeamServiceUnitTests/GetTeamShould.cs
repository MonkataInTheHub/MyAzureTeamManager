using Microsoft.EntityFrameworkCore;
using MyAzureTeamManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyAzureTeamManager.Tests.TeamServiceUnitTests
{
    public class GetTeamShould
    {
        [Fact]
        public async Task GetTeamShouldSucceed()
        {
            //Arrange
            var dbContext = new MyAzureTeamManagerDbContext(Utils.GetOptions($"{Guid.NewGuid()}"));
            Utils.Seed(dbContext);
            var sut = new TeamService(dbContext);
            var id = 2;
            var expected = await dbContext.Teams
                .FirstOrDefaultAsync(p => p.TeamId == id);

            //Act
            var result = await sut.GetAsync(id);

            //Assert
            Assert.Equal(expected.TeamId, result.TeamId);
            Assert.Equal(expected.TeamName, result.TeamName);
        }
    }
}
