using Microsoft.EntityFrameworkCore;
using MyAzureTeamManager.Models;

namespace MyAzureTeamManager.Services
{
    public class FeedbackService : IFeedbackService
    {
        readonly MyAzureTeamManagerDbContext _dbContext;

        public FeedbackService(MyAzureTeamManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Feedback>> GetAllFeedbacksAsync()
        {
            return await _dbContext.Feedbacks.ToListAsync();
        }
        public async Task<Feedback> GetAsync(int feedbackId)
        {
            return await _dbContext.Feedbacks
                .FirstOrDefaultAsync(x => x.FeedbackId == feedbackId);
        }

        public void Create(Feedback feedback)
        {
            _dbContext.Feedbacks.Add(feedback);
            _dbContext.SaveChanges();
        }
        public async System.Threading.Tasks.Task UpdateAsync(Feedback feedbackProvided)
        {
            var Feedback = await _dbContext.Feedbacks
                .FirstOrDefaultAsync(x => x.FeedbackId == feedbackProvided.FeedbackId);
            if (Feedback is null)
            {
                throw new Exception("Feedback does not exist!");
            }

            Feedback.FeedbackId = feedbackProvided.FeedbackId;
            Feedback.Title = feedbackProvided.Title;
            Feedback.Description = feedbackProvided.Description;
            Feedback.Comments = feedbackProvided.Comments;
            Feedback.History = feedbackProvided.History;
            Feedback.FeedbackStatus = feedbackProvided.FeedbackStatus;
            Feedback.Rating = feedbackProvided.Rating;
            _dbContext.SaveChanges();
        }

        public async Task<bool> DeleteAsync(int feedbackId)
        {
            var feedback = await _dbContext.Feedbacks
                .FirstOrDefaultAsync(x => x.FeedbackId == feedbackId);
            if (feedback != null)
            {
                _dbContext.Feedbacks.Remove(feedback);
                _dbContext.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
