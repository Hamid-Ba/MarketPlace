using Framework.Infrastructure;
using MarketPlace.Domain.Entities.Site;
using MarketPlace.Domain.RI.Site;
using MarketPlace.Infrastructure.EfCore.Context;

namespace MarketPlace.Infrastructure.EfCore.Repository.Site
{
    public class SiteSliderRepository : Repository<SiteSlider>, ISiteSliderRepository
    {
        private readonly MarketPlaceContext _context;

        public SiteSliderRepository(MarketPlaceContext context) : base(context) => _context = context;
    }
}