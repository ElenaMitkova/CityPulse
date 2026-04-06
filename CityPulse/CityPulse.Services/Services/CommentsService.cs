using CityPulse.Data;
using CityPulse.Data.Models;
using CityPulse.Services.Common;
using Microsoft.EntityFrameworkCore;

namespace CityPulse.Services.Services
{
    public class CommentsService(ApplicationDbContext context) : ICommentsService
    {
        public async Task AddComment(Comment model)
        {
            model.CreatedOn = DateTime.Now;
            await context.Comments.AddAsync(model);
            await context.SaveChangesAsync();
        }

        public async Task<List<Comment>> GetAllCommentsByReport(int id)
        {
            return await context.Comments.Include(c => c.User).Where(c => c.ReportId == id)
                                        .OrderByDescending(c => c.CreatedOn)
                                        .ToListAsync();
        }


        public async Task DeleteComment(int id)
        {
            Comment comment = context.Comments.Single(x => x.Id == id);
            context.Comments.Remove(comment);
            await context.SaveChangesAsync();
        }
    }
}
