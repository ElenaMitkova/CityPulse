using CityPulse.Services.Common;
using CityPulse.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CityPulse.Controllers
{
    public class LocationsController(ICitiesService citiesService, IDistrictsService districtsService)
        : Controller
    {
        public async Task<IActionResult> Index(int selectedCityId)
        {
            LocationsViewModel model = new LocationsViewModel
            {
                Cities = await citiesService.GetAllCities(),
            };
            if (selectedCityId != 0)
            {
                model.Districts = await districtsService.GetAllDistrictsByCity(selectedCityId);
                ViewData["SelectedCityId"] = selectedCityId;
            }
            return View(model);
        }
    }
}
