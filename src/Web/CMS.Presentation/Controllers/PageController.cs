using CMS.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CMS.Presentation.Controllers
{
    public class PageController : Controller
    {
        private readonly IPageService _pageService;

        public PageController(IPageService pageService) => _pageService = pageService;

        public async Task<IActionResult> Index(string slug)
        {
            var page = await _pageService.GetBySlug(slug);

            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }
    }
}
