using CityPulse.Models;

namespace CityPulse.Services.Models
{
    public class GroupedDistricts
    {
        public string City { get; set; } = null!;
        public IEnumerable<District> Districts { get; set; } = null!;
    }
}
