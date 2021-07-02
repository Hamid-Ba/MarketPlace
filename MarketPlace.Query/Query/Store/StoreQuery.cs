using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Application;
using MarketPlace.Infrastructure.EfCore.Context;
using MarketPlace.Query.Contract.Store;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Query.Query.Store
{
    public class StoreQuery : IStoreQuery
    {
        private readonly MarketPlaceContext _context;

        public StoreQuery(MarketPlaceContext context) => _context = context;

        public async Task<IEnumerable<StoreQueryVM>> GetUserStoresRequestsBy(long userId) => await _context.Stores.Where(s => s.UserId == userId)
            .Select(r => new StoreQueryVM()
            {
                Id = r.Id,
                UserId = r.UserId,
                Status = r.Status,
                Name = r.Name,
                MobileNumber = r.MobileNumber,
                SentRequestTime = r.CreationDate.ToFarsi()
            }).ToListAsync();

    }
}