using CityPulse.Data;
using CityPulse.Models;
using CityPulse.Models.Enums;
using CityPulse.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CityPulse.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext context;
        public ReportsController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<Category> categories = context.Categories.AsNoTracking().ToList();
            IEnumerable<District> districts = context.Districts.AsNoTracking().ToList();
            ViewData["Categories"] = categories;
            ViewData["Districts"] = districts;
            return View(new ReportViewModel());
        }

        [HttpPost]
        public IActionResult Create(ReportViewModel model)
        {
            if (ModelState.IsValid)
            {
                Report report = new Report
                {
                    Title = model.Title,
                    Description = model.Description,
                    CategoryId = model.CategoryId,
                    DistrictId = model.DistrictId,
                    CreatedAt = DateTime.Now,
                    Status = ReportStatus.Pending
                };
                context.Reports.Add(report);
                context.SaveChanges();
                return Ok("fuh");
            }
            return Ok("hfuvhv");
        }
    }
}
