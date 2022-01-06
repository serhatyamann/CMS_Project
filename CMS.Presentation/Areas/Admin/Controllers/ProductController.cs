using CMS.Application.Models.DTOs;
using CMS.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CMS.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            this._productService = productService;
            this._categoryService = categoryService;
        }

        public async Task<IActionResult> Create() => View(new CreateProductDTO() { Categories = await _categoryService.GetCategories() });

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDTO model)
        {

            if (ModelState.IsValid)
            {
                await _productService.Create(model);
                TempData["Success"] = "The product has been added..!";
                return RedirectToAction("List");
            }
            else
            {
                TempData["Error"] = "The product hasn't been added..!";
                model.Categories = await _categoryService.GetCategories();
                return View(model);
            }
        }

        public async Task<IActionResult> List() => View(await _productService.GetProducts());



    }
}
