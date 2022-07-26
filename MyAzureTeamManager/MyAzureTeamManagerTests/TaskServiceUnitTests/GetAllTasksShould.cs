using Microsoft.EntityFrameworkCore;
using MyAzureTeamManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyAzureTeamManager.Tests.TaskServiceUnitTests
{
    public class GetAllTasksShould
    {
        [Fact]
        public async Task GetAllTasksShouldSucceed()
        {
            //Arrange
            var dbContext = new MyAzureTeamManagerDbContext(Utils.GetOptions("GetAllTasksDb"));
            Utils.Seed(dbContext);
            var sut = new TaskService(dbContext);

            //Act
            var result = await sut.GetAllTasksAsync();

            //Assert
            Assert.Equal(String.Join(" ", await dbContext.Tasks.ToListAsync()), String.Join(" ", result));

        }
    }
}
