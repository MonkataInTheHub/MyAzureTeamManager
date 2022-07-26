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
    public class GetAllTeamsShould
    {
        [Fact]
        public async Task GetAllTeamsShouldSucceed()
        {
            //Arrange
            var dbContext = new MyAzureTeamManagerDbContext(Utils.GetOptions("GetAllTeamsDb"));
            Utils.Seed(dbContext);
            var sut = new TeamService(dbContext);

            //Act
            var result = await sut.GetAllTeamsAsync();

            //Assert
            Assert.Equal(String.Join(" ", await dbContext.Teams.ToListAsync()), String.Join(" ", result));

        }
    }
}
