using MyAzureTeamManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyAzureTeamManager.Tests.PersonServiceUnitTests
{
    public class DeletePersonShould
    {
        [Fact]
        public async Task DeletePersonShouldSucceed()
        {
            //Arrange
            const int personId = 3;
            var dbContext = new MyAzureTeamManagerDbContext(Utils.GetOptions("DeletePersonDb"));
            Utils.Seed(dbContext);
            var sut = new PersonService(dbContext);

            //Act
            var result = await sut.DeleteAsync(personId);

            //Assert
            Assert.True(result);
            Assert.True(dbContext.People.FirstOrDefault(x => x.PersonId == personId) == null);
        }
    }
}
