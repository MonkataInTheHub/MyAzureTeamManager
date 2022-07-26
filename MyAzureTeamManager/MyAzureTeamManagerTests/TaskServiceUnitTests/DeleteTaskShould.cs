using MyAzureTeamManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyAzureTeamManager.Tests.TaskServiceUnitTests
{
    public class DeleteTaskShould
    {
        [Fact]
        public async Task DeleteTaskShouldSucceed()
        {
            //Arrange
            const int taskId = 1;
            var dbContext = new MyAzureTeamManagerDbContext(Utils.GetOptions("DeleteTaskDb"));
            Utils.Seed(dbContext);
            var sut = new TaskService(dbContext);

            //Act
            var result = await sut.DeleteAsync(taskId);

            //Assert
            Assert.True(result);
            Assert.True(dbContext.Tasks.FirstOrDefault(x => x.TaskId == taskId) == null);
        }
    }
}
