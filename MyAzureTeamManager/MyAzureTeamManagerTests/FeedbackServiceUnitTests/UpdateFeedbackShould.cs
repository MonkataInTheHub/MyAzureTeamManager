using Microsoft.EntityFrameworkCore;
using MyAzureTeamManager.Models;
using MyAzureTeamManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyAzureTeamManager.Tests.FeedbackServiceUnitTests
{
    public class UpdateFeedbackShould
    {
        [Fact]
        public async System.Threading.Tasks.Task UpdateFeedbackShouldSucceed()
        {
            //Arrange
            var dbContext = new MyAzureTeamManagerDbContext(Utils.GetOptions("UpdateFeedbackDb"));
            Utils.Seed(dbContext);
            var sut = new FeedbackService(dbContext);
            var id = 1;
            var feedback = new Feedback
            {
                Title = "problem",
                Description = "nqkyde",
                FeedbackStatus = Status.Completed,
                History = "",
            };

            //Act
            await sut.UpdateAsync(id, feedback);
            var result = await dbContext.Feedbacks.FirstOrDefaultAsync(x => x.FeedbackId == id);

            //Assert

            Assert.Equal(feedback.Title, result.Title);
            Assert.Equal(feedback.Description, result.Description);
            Assert.Equal(feedback.FeedbackStatus, result.FeedbackStatus);
            Assert.Equal(feedback.History, result.History);
        }
    }
}
