using System.Linq;
using System.Threading.Tasks;
using Framework.Infrastructure;
using MarketPlace.ApplicationContract.ViewModels.PictureAgg;
using MarketPlace.Domain.Entities.StoreAgg.ProductAgg;
using MarketPlace.Domain.RI.StoreAgg.ProductAgg;
using MarketPlace.Infrastructure.EfCore.Context;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.EfCore.Repository.StoreAgg.ProductAgg
{
    public class PictureRepository : Repository<Picture>, IPictureRepository
    {
        private readonly MarketPlaceContext _context;

        public PictureRepository(MarketPlaceContext context) : base(context) => _context = context;

        public async Task<EditPictureVM> GetDetailForEditBy(long id, long productId) => await _context.Pictures
            .Select(p => new EditPictureVM()
            {
                Id = p.Id,
                ProductId = p.ProductId,
                Priority = p.Priority
            }).FirstOrDefaultAsync(p => p.Id == id && p.ProductId == productId);


    }
}
