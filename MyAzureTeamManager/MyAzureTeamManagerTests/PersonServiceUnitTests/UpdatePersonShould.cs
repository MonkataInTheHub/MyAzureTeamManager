using Microsoft.EntityFrameworkCore;
using MyAzureTeamManager.Models;
using MyAzureTeamManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyAzureTeamManager.Tests.PersonServiceUnitTests
{
    public class UpdatePersonShould
    {
        [Fact]
        public async System.Threading.Tasks.Task UpdatePersonShouldSucceed()
        {
            //Arrange
            var dbContext = new MyAzureTeamManagerDbContext(Utils.GetOptions($"{Guid.NewGuid()}"));
            Utils.Seed(dbContext);
            var sut = new PersonService(dbContext);
            var id = 1;
            var person = new Person
            {
                FirstName = "Misho",
                LastName = "Kostenurkata",
                Age = 17,
                TeamId = 0,
            };

            //Act
            await sut.UpdateAsync(id, person);
            var result = await dbContext.People.FirstOrDefaultAsync(x=> x.PersonId == id);

            //Assert

            Assert.Equal(person.FirstName, result.FirstName);
            Assert.Equal(person.LastName, result.LastName);
            Assert.Equal(person.Age, result.Age);
            Assert.Equal(person.TeamId, result.TeamId);
        }
    }
}
