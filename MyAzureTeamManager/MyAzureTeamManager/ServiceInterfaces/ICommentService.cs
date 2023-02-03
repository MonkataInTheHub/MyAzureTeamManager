using MyAzureTeamManager.Models;

namespace MyAzureTeamManager.ServiceInterfaces
{
    public interface ICommentService
    {
        void Create(Comment comment);
        Task<bool> DeleteAsync(int commentId);

        Task<List<Comment>> GetAllCommentsAsync();
    }
}