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
    public class GetAllPeopleShould
    {
        [Fact]
        public async Task GetAllPeopleShouldSucceed()
        {
            //Arrange
            var dbContext = new MyAzureTeamManagerDbContext(Utils.GetOptions("GetAllPeopleDb"));
            Utils.Seed(dbContext);
            var sut = new PersonService(dbContext);

            //Act
            var result = await sut.GetAllPeopleAsync();

            //Assert
            Assert.Equal(String.Join(" ", await dbContext.People.ToListAsync()), String.Join(" ", result));

        }
    }
}
