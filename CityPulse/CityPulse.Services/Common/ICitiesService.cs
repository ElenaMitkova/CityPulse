using CityPulse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityPulse.Services.Common
{
    public interface ICitiesService
    {
        Task<List<City>> GetAllCities();
    }
}
