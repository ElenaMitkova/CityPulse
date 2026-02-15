using CityPulse.Data;
using CityPulse.Models;
using CityPulse.Services.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityPulse.Services.Services
{
    public class CategoriesService(ApplicationDbContext context) : ICategoriesService
    {
        public async Task<List<Category>> GetAllCategories()
        {
            IQueryable<Category> categories = context.Categories;
            return await categories.ToListAsync();
        }
    }
}
