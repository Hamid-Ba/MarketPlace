using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using MarketPlace.Query.Contract.Category;
using MarketPlace.Query.Contract.Product;
using Microsoft.AspNetCore.Routing;
using ReflectionIT.Mvc.Paging;

namespace ServiceHost.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductQuery _productQuery;
        private readonly ICategoryQuery _categoryQuery;

        public ProductsController(IProductQuery productQuery, ICategoryQuery categoryQuery)
        {
            _productQuery = productQuery;
            _categoryQuery = categoryQuery;
        }

        [HttpGet("Products")]
        [HttpGet("Products/{category}")]
        public async Task<IActionResult> Index(ProductMoneyRangeFilter moneyRange, ProductOrderFilter order, string category, int pageIndex = 1)
        {
            var products = await _productQuery.GetProducts(moneyRange, order, category);

            var model = PagingList.Create(products, 12, pageIndex);

            model.RouteValue = new RouteValueDictionary()
            {
                {"selectedMaxValue", moneyRange.SelectedMaxValue},
                {"selectedMinValue", moneyRange.SelectedMinValue},
                {"order", order},
            };

            //UI Section

            var firstProductIndex = (pageIndex * 12) - 11;
            var lastProductIndex = pageIndex * 12;

            if (pageIndex == model.PageCount || products.Count() < 12)
                lastProductIndex = products.Count();

            ViewBag.FirstProductIndex = firstProductIndex;
            ViewBag.LastProductIndex = lastProductIndex;
            ViewBag.ProductsCount = products.Count();

            ViewBag.SelectedMaxVlaue = moneyRange.SelectedMaxValue;
            ViewBag.SelectedMinVlaue = moneyRange.SelectedMinValue;

            ViewBag.Order = order;
            
            if (pageIndex > model.PageCount) return NotFound();

            //Get Categories
            ViewBag.Categories = await _categoryQuery.GetCategories();

            return View(model);
        }
    }
}