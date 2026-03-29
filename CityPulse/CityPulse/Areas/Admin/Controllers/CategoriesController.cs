using CityPulse.Models;
using CityPulse.Services.Common;
using Microsoft.AspNetCore.Mvc;

namespace CityPulse.Areas.Admin.Controllers
{
    public class CategoriesController(ICategoriesService categoriesService) : AdminController
    {
        public async Task<IActionResult> Index()
        {
            List<Category> categories = await categoriesService.GetAllCategories();
            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(new Category());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category model)
        {
            if (ModelState.IsValid)
            {
                await categoriesService.CreateCategory(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await categoriesService.DeleteCategory(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
