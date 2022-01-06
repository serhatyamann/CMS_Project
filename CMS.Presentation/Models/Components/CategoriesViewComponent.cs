using CMS.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CMS.Presentation.Models.Components
{
    public class CategoriesViewComponent:ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public CategoriesViewComponent(ICategoryService categoryService) => this._categoryService = categoryService;

        public async Task<IViewComponentResult> InvokeAsync() => View(await _categoryService.GetCategories());
    }
}
