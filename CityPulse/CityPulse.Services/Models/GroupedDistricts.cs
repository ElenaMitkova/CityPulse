using CityPulse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityPulse.Services.Models
{
    public class GroupedDistricts
    {
        public string City { get; set; } = null!;
        public IEnumerable<District> Districts { get; set; } = null!;
    }
}
