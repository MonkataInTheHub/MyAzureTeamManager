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
    public class GetAllFeedbacksShould
    {
        [Fact]
        public async Task GetAllFeedbacksShouldSucceed()
        {
            //Arrange
            var dbContext = new MyAzureTeamManagerDbContext(Utils.GetOptions("GetAllFeedbacksDb"));
            Utils.Seed(dbContext);
            var sut = new FeedbackService(dbContext);

            //Act
            var result = await sut.GetAllFeedbacksAsync();

            //Assert
            Assert.Equal(String.Join(" ", await dbContext.Feedbacks.ToListAsync()), String.Join(" ", result));

        }
    }
}
