using Microsoft.EntityFrameworkCore;
using MyAzureTeamManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyAzureTeamManager.Tests.PersonServiceUnitTests
{
    public class GetPersonShould
    {
        [Fact]
        public async Task GetPersonShouldSucceed()
        {
            //Arrange
            var dbContext = new MyAzureTeamManagerDbContext(Utils.GetOptions($"{Guid.NewGuid()}"));
            Utils.Seed(dbContext);
            var sut = new PersonService(dbContext);
            var id = 2;
            var expected = await dbContext.People
                .FirstOrDefaultAsync(p => p.PersonId == id);

            //Act
            var result = await sut.GetAsync(id);

            //Assert
            Assert.Equal(expected.PersonId, result.PersonId);
            Assert.Equal(expected.FirstName, result.FirstName);
            Assert.Equal(expected.LastName, result.LastName);
            Assert.Equal(expected.Age, result.Age);
            Assert.Equal(expected.TeamId, result.TeamId);
        }
    }
}
