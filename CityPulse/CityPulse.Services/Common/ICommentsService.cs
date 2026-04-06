namespace CityPulse.Services.Common
{
    public interface ICommentsService
    {
        Task AddCommentAsync(int reportId, string userId, string content);
        Task<bool> DeleteCommentAsync(int commentId, string userId, bool isAdmin);
    }
}