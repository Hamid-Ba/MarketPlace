using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Application;
using MarketPlace.Infrastructure.EfCore.Context;
using MarketPlace.Query.Contract.Product;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Query.Query.Product
{
    public class ProductQuery : IProductQuery
    {
        private readonly MarketPlaceContext _context;

        public ProductQuery(MarketPlaceContext context) => _context = context;

        public async Task<IEnumerable<ProductQueryVM>> GetStoreProducts(long storeId) => await _context.Products
            .Where(p => p.StoreId == storeId).Select(p => new ProductQueryVM()
            {
                Id = p.Id,
                Title = p.Title,
                ImageName = p.ImageName,
                IsActive = p.IsActive,
                Price = p.Price,
                ProductAcceptanceState = p.ProductAcceptanceState,
                StoreId = p.StoreId,
                CreationDate = p.CreationDate.ToFarsi(),
                ProductAcceptOrRejectDescription = p.ProductAcceptOrRejectDescription

            }).AsNoTracking().ToListAsync();

        public async Task<IEnumerable<ProductQueryVM>> GetProducts(ProductMoneyRangeFilter moneyRange, ProductOrderFilter order, string categoryUrl)
        {
            var query = _context.Products.Include(c => c.Categories).ThenInclude(c => c.Category)
                .Where(p => p.IsActive && p.ProductAcceptanceState == ProductAcceptanceState.Accepted)
                .AsNoTracking().AsQueryable();

            #region Filtering

            query = query.Where(q => q.Price >= moneyRange.SelectedMinValue);

            if (moneyRange.SelectedMaxValue > 0)
                query = query.Where(q => q.Price <= moneyRange.SelectedMaxValue);

            if (!string.IsNullOrWhiteSpace(categoryUrl))
                query = query.Where(q => q.Categories.Any(c => c.Category.UrlName == categoryUrl));

            #endregion

            #region Sorting

            switch (order)
            {
                case ProductOrderFilter.Title:
                    query = query.OrderByDescending(q => q.Title);
                    break;
                case ProductOrderFilter.Price_Dec:
                    query = query.OrderByDescending(q => q.Price);
                    break;
                case ProductOrderFilter.Price_Ace:
                    query = query.OrderBy(q => q.Price);
                    break;
            }

            #endregion

            return await query.Select(p => new ProductQueryVM()
            {
                Id = p.Id,
                StoreId = p.StoreId,
                Title = p.Title,
                ImageName = p.ImageName,
                Price = p.Price,
                ShortDescription = p.ShortDescription
            }).ToListAsync();
        }
    }
}