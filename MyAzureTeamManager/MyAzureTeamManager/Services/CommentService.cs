using Microsoft.EntityFrameworkCore;
using MyAzureTeamManager.Models;
using MyAzureTeamManager.ServiceInterfaces;

namespace MyAzureTeamManager.Services
{
    public class CommentService : ICommentService
    {
        readonly MyAzureTeamManagerDbContext _dbContext;
        public CommentService(MyAzureTeamManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(Comment comment)
        {
            _dbContext.Comments.Add(comment);
            _dbContext.SaveChanges();
        }
        public async Task<bool> DeleteAsync(int commentId)
        {
            var comment = await _dbContext.Comments
                .FirstOrDefaultAsync(x => x.CommentId == commentId);
            if (comment != null)
            {
                _dbContext.Comments.Remove(comment);
                _dbContext.SaveChanges();
                return true;
            }

            return false;
        }
        public async Task<List<Comment>> GetAllCommentsAsync()
        {
            return await _dbContext.Comments.ToListAsync();
        }
    }
}
