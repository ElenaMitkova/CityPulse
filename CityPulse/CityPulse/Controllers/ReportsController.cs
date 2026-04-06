using CityPulse.Areas.Identity.Pages.Account;
using CityPulse.Data;
using CityPulse.Models;
using CityPulse.Models.Enums;
using CityPulse.Services.Common;
using CityPulse.Services.Models;
using CityPulse.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Security.Claims;
using static CityPulse.Common.EntityValidations;
namespace CityPulse.Controllers
{
    public class ReportsController(IReportsService reportsService, ICategoriesService categoriesService,
                                    IDistrictsService districtsService, ICitiesService citiesService, ICommentsService commentsService) 
        : Controller
    {
        public async Task<IActionResult> Index(int? categoryId, string? searchTerm = null,
                                               int currentPage = 1)
        {
            ReportServiceModel model = await reportsService.GetAllReports(searchTerm, currentPage);
            List<ReportModel> reportModels = model.Reports.ToList();
            if (categoryId.HasValue)
            {
                reportModels = reportModels.Where(x => x.CategoryId == categoryId).ToList();
            }
            ViewData["Categories"] = await categoriesService.GetAllCategories();
            ViewData["SelectedCategoryId"] = categoryId;
            ViewData["TotalReportsCount"] = model.TotalReportsCount;
            return View(reportModels);
        }

        public async Task<IActionResult> Details(int id)
        {
            ReportModel model = await reportsService.GetReportById(id);
            model.Comments = await commentsService.GetAllCommentsByReport(id);
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
                List<ReportModel> models = await reportsService.GetAll();
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
                List<ReportModel> models = await reportsService.GetAll();
                await reportsService.UpdateReport(model);
                return RedirectToAction(nameof(Index), models);
            }
            ViewData["Districts"] = await districtsService.GetAllDistrictsByGroup();
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var report = await reportsService.GetReportById(id);
            if (report == null)
            {
                return NotFound();
            }
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (report.UserId != currentUserId)
            {
                return Forbid();
            }
            await reportsService.DeleteReport(report);
            return RedirectToAction(nameof(Index));
        }
    }
}
