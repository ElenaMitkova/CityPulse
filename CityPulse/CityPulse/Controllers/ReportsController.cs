using CityPulse.Data;
using CityPulse.Models;
using CityPulse.Models.Enums;
using CityPulse.Services.Common;
using CityPulse.Services.Models;
using CityPulse.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static CityPulse.Common.EntityValidations;
using CityPulse.Areas.Identity.Pages.Account;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
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

        public async Task<IActionResult> MySignals(int? categoryId)
        {
            List<ReportModel> models = await reportsService.GetReportsByUser(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (categoryId.HasValue)
            {
                models = models.Where(x => x.CategoryId == categoryId).ToList();
            }
            ViewData["Categories"] = await categoriesService.GetAllCategories();
            ViewData["SelectedCategoryId"] = categoryId;
            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            if (!User.Identity?.IsAuthenticated ?? true)
            {
                return Redirect("/Identity/Account/Login");
            }
            ViewData["Categories"] = await categoriesService.GetAllCategories();
            ViewData["Districts"] = await districtsService.GetAllDistrictsByGroup();
            return View(new ReportModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReportModel model)
        {
            model.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (ModelState.IsValid)
            {
                List<ReportModel> models = await reportsService.GetAllReports();
                await reportsService.CreateReport(model, User.FindFirstValue(ClaimTypes.NameIdentifier));
                return RedirectToAction(nameof(Index), models);
            }
            ViewData["Categories"] = await categoriesService.GetAllCategories();
            ViewData["Districts"] = await districtsService.GetAllDistrictsByGroup();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ReportModel model = await reportsService.GetReportById(id);
            ViewData["Districts"] = await districtsService.GetAllDistrictsByGroup();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ReportModel model)
        {
            if (ModelState.IsValid)
            {
                List<ReportModel> models = await reportsService.GetAllReports();
                await reportsService.UpdateReport(model);
                return RedirectToAction(nameof(Index), models);
            }
            ViewData["Districts"] = await districtsService.GetAllDistrictsByGroup();
            return View(model);
        }
    }
}
