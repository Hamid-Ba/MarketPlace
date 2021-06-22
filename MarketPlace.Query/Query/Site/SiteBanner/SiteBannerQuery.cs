using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Application;
using MarketPlace.Infrastructure.EfCore.Context;
using MarketPlace.Query.Contract.Site.SiteBanner;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Query.Query.Site.SiteBanner
{
    public class SiteBannerQuery : ISiteBannerQuery
    {
        private readonly MarketPlaceContext _context;

        public SiteBannerQuery(MarketPlaceContext context) => _context = context;

        public async Task<IEnumerable<SiteBannerQueryVM>> GetBannersBy(IEnumerable<BannerPosition> positions) =>
            await _context.SiteBanners.Where(b => positions.Contains(b.Position)).Select(b => new SiteBannerQueryVM()
            {
                ImageName = b.ImageName,
                ColSize = b.ColSize,
                Position = b.Position,
                Url = b.Url
            }).ToListAsync();
    }
}