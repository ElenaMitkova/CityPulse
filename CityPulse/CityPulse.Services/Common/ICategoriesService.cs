using CityPulse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityPulse.Services.Common
{
    public interface ICategoriesService
    {
        Task<List<Category>> GetAllCategories();
        Task CreateCategory(Category category);
        Task DeleteCategory(int id);
    }
}
