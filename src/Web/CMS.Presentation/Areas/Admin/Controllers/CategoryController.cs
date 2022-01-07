using CMS.Application.Models.DTOs;
using CMS.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CMS.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService) => this._categoryService = categoryService;

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                TempData["Success"] = "The category has been added..!";
                await _categoryService.Create(model);
                return RedirectToAction("List");
            }
            else
            {
                TempData["Error"] = "The category hasn't been added..!";
                return View(model);
            }
        }

        public async Task<IActionResult> List() => View(await _categoryService.GetCategories());

        public async Task<IActionResult> Update(int id) => View(await _categoryService.GetById(id));

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                TempData["Success"] = "The category has been updated..!";
                await _categoryService.Update(model);
                return RedirectToAction("List");
            }
            else
            {
                TempData["Error"] = "The category hasn't been updated..!";
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.Delete(id);
            return RedirectToAction("List");
        }
    }
}
