using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Application;
using MarketPlace.Infrastructure.EfCore.Context;
using MarketPlace.Query.Contract.Product;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Query.Query.Product
{
    public class ProductQuery  : IProductQuery
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

    }
}
