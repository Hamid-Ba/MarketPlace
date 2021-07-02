using System.Linq;
using System.Threading.Tasks;
using Framework.Infrastructure;
using MarketPlace.ApplicationContract.ViewModels.StoreAgg;
using MarketPlace.Domain.Entities.StoreAgg;
using MarketPlace.Domain.RI.StoreAgg;
using MarketPlace.Infrastructure.EfCore.Context;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.EfCore.Repository.StoreAgg
{
    public class StoreRepository : Repository<Store>, IStoreRepository
    {
        private readonly MarketPlaceContext _context;

        public StoreRepository(MarketPlaceContext context) : base(context) => _context = context;

        public async Task<EditStoreRequestVM> GetDetailForEditBy(long id) => await _context.Stores.Select(s =>
            new EditStoreRequestVM()
            {
                Id = s.Id,
                UserId = s.UserId,
                Name = s.Name,
                MobileNumber = s.MobileNumber,
                Address = s.Address
            }).FirstOrDefaultAsync(s => s.Id == id);
    }
}