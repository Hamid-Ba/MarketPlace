using Framework.Infrastructure;
using MarketPlace.Domain.Entities.StoreAgg.ProductAgg;
using MarketPlace.Domain.RI.StoreAgg.ProductAgg;
using MarketPlace.Infrastructure.EfCore.Context;

namespace MarketPlace.Infrastructure.EfCore.Repository.StoreAgg.ProductAgg
{
    public class ProductCategoryRepository : Repository<Product_Category> , IProductCategoryRepository
    {
        private readonly MarketPlaceContext _context;

        public ProductCategoryRepository(MarketPlaceContext context) : base(context) => _context = context;

    }
}
