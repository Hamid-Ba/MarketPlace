using Framework.Infrastructure;
using MarketPlace.Domain.Entities.StoreAgg;
using MarketPlace.Domain.RI.StoreAgg;
using MarketPlace.Infrastructure.EfCore.Context;

namespace MarketPlace.Infrastructure.EfCore.Repository.StoreAgg
{
    public class StoreRepository : Repository<Store> , IStoreRepository
    {
        private readonly MarketPlaceContext _context;

        public StoreRepository(MarketPlaceContext context) : base(context) => _context = context;
    }
}