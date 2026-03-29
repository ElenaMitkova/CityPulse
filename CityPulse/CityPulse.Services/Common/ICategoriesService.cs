using CityPulse.Models;

namespace CityPulse.Services.Common
{
    public interface ICategoriesService
    {
        Task<List<Category>> GetAllCategories();
        Task CreateCategory(Category category);
        Task DeleteCategory(int id);
    }
}
