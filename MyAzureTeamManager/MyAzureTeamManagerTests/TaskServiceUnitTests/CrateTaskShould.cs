using Microsoft.EntityFrameworkCore;
using MyAzureTeamManager;
using MyAzureTeamManager.Models;
using MyAzureTeamManager.Services;
using MyAzureTeamManager.Tests;
using System.Linq;
using Xunit;

namespace MyAzureTeamManagerTests.Tests.TaskServiceUnitTests
{
    public class CreateTaskShould
    {
        [Fact]
        public void CreateTaskShouldSucceed()
        {
            //Arrange
            var dbContext = new MyAzureTeamManagerDbContext(Utils.GetOptions("CreateTaskDb"));
            var sut = new TaskService(dbContext);
            var task = new Task
            {
                Title = "title",
                Description = "description",
                BoardId = 4,
                Priority = Priority.Low,
                TaskStatus = Status.New,
                History = ""
            };

            //Act
            sut.Create(task);
            var result = dbContext.Tasks.FirstOrDefault(p => p.TaskId == task.TaskId);

            //Assert
            Assert.Equal(task.TaskId, result.TaskId);
            Assert.Equal(task.Title, result.Title);
            Assert.Equal(task.Description, result.Description);
            Assert.Equal(task.BoardId, result.BoardId);
            Assert.Equal(task.Priority, result.Priority);
            Assert.Equal(task.TaskStatus, result.TaskStatus);
        }
    }
}