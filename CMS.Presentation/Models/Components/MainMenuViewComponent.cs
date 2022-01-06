using CMS.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CMS.Presentation.Models.Components
{
    public class MainMenuViewComponent:ViewComponent
    {
        private readonly IPageService _pageService;

        public MainMenuViewComponent(IPageService pageService) => this._pageService = pageService;

        public async Task<IViewComponentResult> InvokeAsync() => View(await _pageService.GetPages());
    }
}
