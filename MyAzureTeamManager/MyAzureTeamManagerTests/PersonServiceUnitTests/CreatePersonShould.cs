using Microsoft.EntityFrameworkCore;
using MyAzureTeamManager;
using MyAzureTeamManager.Models;
using MyAzureTeamManager.Services;
using MyAzureTeamManager.Tests;
using System.Linq;
using Xunit;

namespace MyAzureTeamManagerTests
{
    public class CreatePersonShould
    {
        [Fact]
        public void CreatePersonShouldSucceed()
        {
            //Arrange
            var dbContext = new MyAzureTeamManagerDbContext(Utils.GetOptions("CreatePersonDb"));
            var sut = new PersonService(dbContext);
            var person = new Person
            {
                FirstName = "Ivo",
                LastName = "Babankata",
                Age = 17,
                TeamId = 0,
            };

            //Act
            sut.Create(person);
            var result = dbContext.People.FirstOrDefault(p => p.PersonId == person.PersonId);

            //Assert
            Assert.Equal(person.PersonId, result.PersonId);
            Assert.Equal(person.FirstName, result.FirstName);
            Assert.Equal(person.LastName, result.LastName);
            Assert.Equal(person.Age, result.Age);
            Assert.Equal(person.TeamId, result.TeamId);
        }
    }
}