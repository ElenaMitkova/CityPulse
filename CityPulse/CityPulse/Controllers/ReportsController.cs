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
    public class ReportsController(IReportsService reportsService, ICategoriesService categoriesService) 
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
        //[HttpGet]
        //public IActionResult Create()
        //{
        //    IEnumerable<Category> categories = context.Categories.AsNoTracking().ToList();
        //    IEnumerable<District> districts = context.Districts.AsNoTracking().ToList();
        //    ViewData["Categories"] = categories;
        //    ViewData["Districts"] = districts;
        //    return View(new ReportViewModel());
        //}

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
