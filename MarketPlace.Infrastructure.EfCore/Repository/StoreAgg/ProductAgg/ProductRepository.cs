using Framework.Infrastructure;
using MarketPlace.Domain.Entities.StoreAgg.ProductAgg;
using MarketPlace.Domain.RI.StoreAgg.ProductAgg;
using MarketPlace.Infrastructure.EfCore.Context;

namespace MarketPlace.Infrastructure.EfCore.Repository.StoreAgg.ProductAgg
{
    public class ProductRepository : Repository<Product> , IProductRepository
    {
        private readonly MarketPlaceContext _context;

        public ProductRepository(MarketPlaceContext context) : base(context) => _context = context;

    }
}
