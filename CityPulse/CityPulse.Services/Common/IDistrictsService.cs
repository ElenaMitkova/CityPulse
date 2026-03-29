using CityPulse.Models;
using CityPulse.Services.Models;

namespace CityPulse.Services.Common
{
    public interface IDistrictsService
    {
        Task<List<District>> GetAllDistricts();
        Task<List<GroupedDistricts>> GetAllDistrictsByGroup();
        Task<List<District>> GetAllDistrictsByCity(int cityId);
        Task CreateDistrict(District model, int id);
        Task DeleteDistrict(int id);
    }
}
