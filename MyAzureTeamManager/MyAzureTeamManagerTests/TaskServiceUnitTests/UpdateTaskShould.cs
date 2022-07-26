using Microsoft.EntityFrameworkCore;
using MyAzureTeamManager.Models;
using MyAzureTeamManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyAzureTeamManager.Tests.TaskServiceUnitTests
{
    public class UpdateTaskShould
    {
        [Fact]
        public async System.Threading.Tasks.Task UpdateTaskShouldSucceed()
        {
            //Arrange
            var dbContext = new MyAzureTeamManagerDbContext(Utils.GetOptions("UpdateTaskDb"));
            Utils.Seed(dbContext);
            var sut = new TaskService(dbContext);
            var id = 1;
            var task = new Models.Task
            {
                Title = "problem",
                Description = "nqkyde",
                TaskStatus = Status.Completed,
                History = "",
                BoardId = 2,
                Priority = Priority.Low
            };

            //Act
            await sut.UpdateAsync(id, task);
            var result = await dbContext.Tasks.FirstOrDefaultAsync(x => x.TaskId == id);

            //Assert

            Assert.Equal(task.Title, result.Title);
            Assert.Equal(task.Description, result.Description);
            Assert.Equal(task.TaskStatus, result.TaskStatus);
            Assert.Equal(task.History, result.History);
            Assert.Equal(task.BoardId, result.BoardId);
            Assert.Equal(task.Priority, result.Priority);
        }
    }
}
