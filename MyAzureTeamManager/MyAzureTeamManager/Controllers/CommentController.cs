using Microsoft.AspNetCore.Mvc;
using MyAzureTeamManager.Models;
using MyAzureTeamManager.ServiceInterfaces;

namespace MyAzureTeamManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpPost]
        public void Create([FromBody] Comment comment)
        {
            _commentService.Create(comment);
        }
        [HttpGet("GetAllComments")]
        public async Task<IEnumerable<Comment>> GetAllComments()
        {
            return await _commentService.GetAllCommentsAsync();
        }
        [HttpDelete]
        public void Delete([FromBody] int commentId)
        {
            _commentService.DeleteAsync(commentId);
        }
    }
}
