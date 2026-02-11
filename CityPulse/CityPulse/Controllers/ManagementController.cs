using Microsoft.AspNetCore.Mvc;

namespace CityPulse.Controllers
{
    public class ManagementController : Controller
    {
        public IActionResult Map()
        {
            return View();
        }
    }
}
