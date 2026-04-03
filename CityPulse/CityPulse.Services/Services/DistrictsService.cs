using CityPulse.Data;
using CityPulse.Models;
using CityPulse.Services.Common;
using CityPulse.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace CityPulse.Services.Services
{
    public class DistrictsService(ApplicationDbContext context) : IDistrictsService
    {
        public async Task<List<District>> GetAllDistricts()
        {
            IQueryable<District> districts = context.Districts.Include(x => x.City);
            return await districts.ToListAsync();
        }
        public async Task<List<GroupedDistricts>> GetAllDistrictsByGroup()
        {
            IQueryable<GroupedDistricts> districts = context.Cities.Include(x => x.Districts)
                                                    .Select(x => new GroupedDistricts
                                                    {
                                                        City = x.Name,
                                                        Districts = x.Districts.ToList()
                                                    });
            return await districts.ToListAsync();
        }

        public async Task<List<District>> GetAllDistrictsByCity(int cityId)
        {
            IQueryable<District> districts = context.Districts.Where(x => x.CityId == cityId);
            return await districts.ToListAsync();
        }

        public async Task CreateDistrict(District model, int id)
        {
            model.CityId = id;
            await context.Districts.AddAsync(model);
            await context.SaveChangesAsync();
        }

        public async Task DeleteDistrict(int districtId)
        {
            District district = context.Districts.Single(x => x.Id == districtId);
            context.Districts.Remove(district);
            await context.SaveChangesAsync();
        }
    }
}
