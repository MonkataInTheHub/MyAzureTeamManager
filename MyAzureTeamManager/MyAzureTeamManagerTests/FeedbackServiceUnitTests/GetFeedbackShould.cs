using Microsoft.EntityFrameworkCore;
using MyAzureTeamManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyAzureTeamManager.Tests.FeedbackServiceUnitTests
{
    public class GetFeedbackShould
    {
        [Fact]
        public async Task GetFeedbackShouldSucceed()
        {
            //Arrange
            var dbContext = new MyAzureTeamManagerDbContext(Utils.GetOptions($"{Guid.NewGuid()}"));
            Utils.Seed(dbContext);
            var sut = new FeedbackService(dbContext);
            var id = 2;
            var expected = await dbContext.Feedbacks
                .FirstOrDefaultAsync(p => p.FeedbackId == id);

            //Act
            var result = await sut.GetAsync(id);

            //Assert
            Assert.Equal(expected.FeedbackId, result.FeedbackId);
            Assert.Equal(expected.Title, result.Title);
            Assert.Equal(expected.Description, result.Description);
            Assert.Equal(expected.FeedbackStatus, result.FeedbackStatus);
            Assert.Equal(expected.History, result.History);
        }
    }
}
