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

        public async Task CreateCity(City model)
        {
            City city = new City();
            city.Name = model.Name;
            await context.Cities.AddAsync(city);
            await context.SaveChangesAsync();
        }

        public async Task DeleteCity(int id)
        {
            City city = context.Cities.Single(x => x.Id == id);
            context.Cities.Remove(city);
            await context.SaveChangesAsync();
        }

        public Task<City> GetCityById(int id)
        {
            IQueryable<City> city = context.Cities;
            return city.SingleAsync(x => x.Id == id);
        }
    }
}
