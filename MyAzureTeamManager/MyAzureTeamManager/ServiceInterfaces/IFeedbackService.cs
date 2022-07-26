using MyAzureTeamManager.Models;

namespace MyAzureTeamManager.Services
{
    public interface IFeedbackService
    {
        void Create(Feedback Feedback);
        Task<bool> DeleteAsync(int feedbackId);
        Task<List<Feedback>> GetAllFeedbacksAsync();
        Task<Feedback> GetAsync(int feedbackId);
        System.Threading.Tasks.Task UpdateAsync(int id, Feedback FeedbackProvided);
    }
}