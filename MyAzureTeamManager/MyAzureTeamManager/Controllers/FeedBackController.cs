using Microsoft.AspNetCore.Mvc;
using MyAzureTeamManager.Models;
using MyAzureTeamManager.Models.Interfaces;
using MyAzureTeamManager.Services;

namespace MyAzureTeamManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        readonly IFeedbackService _feedbackService;
        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet("GetAllFeedbacks")]
        public async Task<IEnumerable<Feedback>> GetAllFeedbacks()
        {
            return await _feedbackService.GetAllFeedbacksAsync();
        }

        [HttpGet("GetFeedback")]
        public async Task<IFeedback> Get(int feedbackId)
        {
            return await _feedbackService.GetAsync(feedbackId);
        }

        [HttpPost]
        public void Create([FromBody] Feedback feedback)
        {
            _feedbackService.Create(feedback);
        }

        [HttpPut]
        public async System.Threading.Tasks.Task Update(int id, [FromBody] Feedback feedback)
        {
            await _feedbackService.UpdateAsync(id, feedback);
        }

        [HttpDelete]
        public void Delete([FromBody] int feedbackId)
        {
            _feedbackService.DeleteAsync(feedbackId);
        }
    }
}
