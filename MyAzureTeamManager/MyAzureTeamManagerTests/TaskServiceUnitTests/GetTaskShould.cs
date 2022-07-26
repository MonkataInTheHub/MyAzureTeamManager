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
    public class GetTaskShould
    {
        [Fact]
        public async Task GetTaskShouldSucceed()
        {
            //Arrange
            var dbContext = new MyAzureTeamManagerDbContext(Utils.GetOptions($"{Guid.NewGuid()}"));
            Utils.Seed(dbContext);
            var sut = new TaskService(dbContext);
            var id = 2;
            var expected = await dbContext.Tasks
                .FirstOrDefaultAsync(p => p.TaskId == id);

            //Act
            var result = await sut.GetAsync(id);

            //Assert
            Assert.Equal(expected.TaskId, result.TaskId);
            Assert.Equal(expected.Title, result.Title);
            Assert.Equal(expected.Description, result.Description);
            Assert.Equal(expected.TaskStatus, result.TaskStatus);
            Assert.Equal(expected.History, result.History);
            Assert.Equal(expected.BoardId, result.BoardId);
            Assert.Equal(expected.Priority, result.Priority);
        }
    }
}
