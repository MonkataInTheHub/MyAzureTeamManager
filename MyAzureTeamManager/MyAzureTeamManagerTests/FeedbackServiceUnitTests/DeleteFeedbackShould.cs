using MyAzureTeamManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyAzureTeamManager.Tests.FeedbackServiceUnitTests
{
    public class DeleteFeedbackShould
    {
        [Fact]
        public async Task DeleteFeedbackShouldSucceed()
        {
            //Arrange
            const int feedbackId = 3;
            var dbContext = new MyAzureTeamManagerDbContext(Utils.GetOptions("DeleteFeedbackDb"));
            Utils.Seed(dbContext);
            var sut = new FeedbackService(dbContext);

            //Act
            var result = await sut.DeleteAsync(feedbackId);

            //Assert
            Assert.True(result);
            Assert.True(dbContext.Feedbacks.FirstOrDefault(x => x.FeedbackId == feedbackId) == null);
        }
    }
}
