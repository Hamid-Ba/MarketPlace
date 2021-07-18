using System.Threading.Tasks;
using MarketPlace.Query.Contract.Category;
using MarketPlace.Query.Contract.Site.SiteSlider;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class SiteHeaderViewComponent : ViewComponent
    {
        private readonly ICategoryQuery _categoryQuery;

        public SiteHeaderViewComponent(ICategoryQuery categoryQuery) => _categoryQuery = categoryQuery;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _categoryQuery.GetCategories());
        }
    }

    public class SiteFooterViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }

    public class SiteSliderViewComponent : ViewComponent
    {
        private readonly ISiteSliderQuery _siteSliderQuery;

        public SiteSliderViewComponent(ISiteSliderQuery siteSliderQuery) => _siteSliderQuery = siteSliderQuery;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _siteSliderQuery.GetAllSliderForMainPage());
        }
    }
}
