using CityPulse.Data.Models;

namespace CityPulse.Services.Common
{
    public interface ICommentsService
    {
        Task AddComment(Comment comment);
        Task DeleteComment(int id);
        Task<List<Comment>> GetAllCommentsByReport(int id);
    }
}