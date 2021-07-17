using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Infrastructure;
using MarketPlace.Domain.Entities.StoreAgg.ProductAgg;
using MarketPlace.Domain.RI.StoreAgg.ProductAgg;
using MarketPlace.Infrastructure.EfCore.Context;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.EfCore.Repository.StoreAgg.ProductAgg
{
    public class ProductCategoryRepository : Repository<Product_Category> , IProductCategoryRepository
    {
        private readonly MarketPlaceContext _context;

        public ProductCategoryRepository(MarketPlaceContext context) : base(context) => _context = context;

        public async Task<IEnumerable<Product_Category>> GetProductCategoriesBy(long productId) =>
            await _context.ProductCategories.Where(c => c.ProductId == productId).ToListAsync();
    }
}
