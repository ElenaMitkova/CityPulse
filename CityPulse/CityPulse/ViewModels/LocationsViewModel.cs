using CityPulse.Models;

namespace CityPulse.ViewModels
{
    public class LocationsViewModel
    {
        public IEnumerable<City> Cities { get; set; } = new HashSet<City>();
        public IEnumerable<District> Districts { get; set; } = new HashSet<District>();
    }
}
