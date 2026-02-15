using CityPulse.Data;
using CityPulse.Models;
using CityPulse.Models.Enums;
using CityPulse.Services.Common;
using CityPulse.Services.Models;
using CityPulse.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CityPulse.Controllers
{
    public class ReportsController(IReportsService reportsService, ICategoriesService categoriesService,
                                    IDistrictsService districtsService, ICitiesService citiesService) 
        : Controller
    {
        public async Task<IActionResult> Index(int? categoryId)
        {
            List<ReportModel> models = await reportsService.GetAllReports();
            if (categoryId.HasValue)
            {
                models = models.Where(x => x.CategoryId == categoryId).ToList();
            }
            ViewData["Categories"] = await categoriesService.GetAllCategories();
            ViewData["SelectedCategoryId"] = categoryId;
            return View(models);
        }

        public async Task<IActionResult> Details(int id)
        {
            ReportModel model = await reportsService.GetReportById(id);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["Categories"] = await categoriesService.GetAllCategories();
            ViewData["Districts"] = await districtsService.GetAllDistrictsByGroup();
            return View(new ReportModel());
        }

        //[HttpPost]
        //public IActionResult Create(ReportViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        return Ok("ok");
        //    }
        //    return Ok("not ok");
        //}
    }
}
