using CityPulse.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityPulse.Controllers
{
    public class ReportsController : Controller
    {
        public IActionResult Create()
        {
            return View(new Report());
        }
    }
}
