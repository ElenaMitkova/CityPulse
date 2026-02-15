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
    public class CitiesService(ApplicationDbContext context) : ICitiesService
    {
        public async Task<List<City>> GetAllCities()
        {
            IQueryable<City> cities = context.Cities;
            return await cities.ToListAsync();
        }
    }
}
