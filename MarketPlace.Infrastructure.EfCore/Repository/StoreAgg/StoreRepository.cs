using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Application;
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

        public async Task<IEnumerable<AdminStoreRequestVM>> GetAllForAdmin() => await _context.Stores
            .Include(u => u.User)
            .Select(s => new AdminStoreRequestVM()
            {
                Id = s.Id,
                UserId = s.UserId,
                UserFullName = $"{s.User.FirstName} {s.User.LastName}",
                MobileNumber = s.MobileNumber,
                Status = s.Status,
                CreationDate = s.CreationDate.ToFarsi(),
                StoreName = s.Name
            }).AsNoTracking().ToListAsync();

        public async Task<bool> IsStoreBelongToUser(long id, long userId) => await _context.Stores.AnyAsync(s => s.Id == id && s.UserId == userId && s.Status == StoreStatus.Confirmed);

    }
}