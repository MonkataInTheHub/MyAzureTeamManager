using Microsoft.EntityFrameworkCore;
using MyAzureTeamManager;
using MyAzureTeamManager.Models;
using MyAzureTeamManager.Services;
using MyAzureTeamManager.Tests;
using System.Linq;
using Xunit;

namespace MyAzureTeamManagerTests.Tests.FeedbackServiceUnitTests
{
    public class CreateFeedbackShould
    {
        [Fact]
        public void CreateFeedbackShouldSucceed()
        {
            //Arrange
            var dbContext = new MyAzureTeamManagerDbContext(Utils.GetOptions("CreateFeedbackDb"));
            var sut = new FeedbackService(dbContext);
            var team = new Feedback
            {
                Title = "title",
                Description = "description",
                FeedbackStatus = Status.New,
                History = ""
            };

            //Act
            sut.Create(team);
            var result = dbContext.Feedbacks.FirstOrDefault(p => p.FeedbackId == team.FeedbackId);

            //Assert
            Assert.Equal(team.FeedbackId, result.FeedbackId);
            Assert.Equal(team.Title, result.Title);
            Assert.Equal(team.Description, result.Description);
            Assert.Equal(team.FeedbackStatus, result.FeedbackStatus);
        }
    }
}