using CityPulse.Data;
using CityPulse.Models;
using CityPulse.Services.Common;
using CityPulse.Services.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
