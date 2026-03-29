using CityPulse.Data;
using CityPulse.Models;
using CityPulse.Services.Common;
using Microsoft.EntityFrameworkCore;

namespace CityPulse.Services.Services
{
    public class CategoriesService(ApplicationDbContext context) : ICategoriesService
    {
        public async Task<List<Category>> GetAllCategories()
        {
            IQueryable<Category> categories = context.Categories.Include(x => x.Reports);
            return await categories.ToListAsync();
        }
        public async Task CreateCategory(Category model)
        {
            Category category = new Category();
            category.Name = model.Name;
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
        }

        public async Task DeleteCategory(int id)
        {
            Category category = context.Categories.Single(x => x.Id == id);
            context.Categories.Remove(category);
            await context.SaveChangesAsync();
        }

    }
}
