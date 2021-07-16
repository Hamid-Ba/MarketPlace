using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Infrastructure;
using MarketPlace.Domain.Entities.StoreAgg.ProductAgg;
using MarketPlace.Domain.RI.StoreAgg.ProductAgg;
using MarketPlace.Infrastructure.EfCore.Context;

namespace MarketPlace.Infrastructure.EfCore.Repository.StoreAgg.ProductAgg
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly MarketPlaceContext _context;

        public CategoryRepository(MarketPlaceContext context) : base(context) => _context = context;
    }
}
