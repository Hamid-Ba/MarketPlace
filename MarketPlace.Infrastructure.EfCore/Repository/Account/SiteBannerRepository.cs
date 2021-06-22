using Framework.Infrastructure;
using MarketPlace.Domain.Entities.Site;
using MarketPlace.Domain.RI.Site;
using MarketPlace.Infrastructure.EfCore.Context;

namespace MarketPlace.Infrastructure.EfCore.Repository.Account
{
    public class SiteBannerRepository : Repository<SiteBanner>, ISiteBannerRepository
    {
        private readonly MarketPlaceContext _context;

        public SiteBannerRepository(MarketPlaceContext context) : base(context) => _context = context;
    }
}