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
    public class DistrictsService(ApplicationDbContext context) : IDistrictsService
    {
        public async Task<List<District>> GetAllDistricts()
        {
            IQueryable<District> districts = context.Districts.Include(x => x.City);
            return await districts.ToListAsync();
        }
    }
}
