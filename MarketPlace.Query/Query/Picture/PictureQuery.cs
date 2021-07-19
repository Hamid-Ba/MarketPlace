using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketPlace.Infrastructure.EfCore.Context;
using MarketPlace.Query.Contract.Picture;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Query.Query.Picture
{
    public class PictureQuery : IPictureQuery
    {
        private readonly MarketPlaceContext _context;

        public PictureQuery(MarketPlaceContext context) => _context = context;


        public async Task<IEnumerable<PictureQueryVM>> GetPicturesBy(long productId) => await _context.Pictures
            .Where(p => p.ProductId == productId)
            .Select(p => new PictureQueryVM()
            {
                Id = p.Id,
                ProductId = p.ProductId,
                Priority = p.Priority,
                ImageName = p.ImageName
            }).OrderBy(p => p.Priority).AsNoTracking().ToListAsync();

    }
}