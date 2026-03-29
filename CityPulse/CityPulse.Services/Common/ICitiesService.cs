using CityPulse.Models;

namespace CityPulse.Services.Common
{
    public interface ICitiesService
    {
        Task<List<City>> GetAllCities();
        Task<City> GetCityById(int id);
        Task CreateCity(City model);
        Task DeleteCity(int id);
    }
}
