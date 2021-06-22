using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketPlace.Infrastructure.EfCore.Context;
using MarketPlace.Query.Contract.Site.SiteSlider;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Query.Query.Site.SiteSlider
{
    public class SiteSliderQuery : ISiteSliderQuery
    {
        private readonly MarketPlaceContext _marketPlaceContext;

        public SiteSliderQuery(MarketPlaceContext marketPlaceContext) => _marketPlaceContext = marketPlaceContext;

        public async Task<IEnumerable<SiteSliderQueryVM>> GetAllSliderForMainPage() => await _marketPlaceContext.SiteSliders.Where(s => s.IsDisplay).
            Select(s => new SiteSliderQueryVM()
            {
                FirstHeader = s.FirstHeader,
                SecondHeader = s.SecondHeader,
                Description = s.Description,
                ImageName = s.ImageName,
                Link = s.Link,
                TextButton = s.TextButton
            }).ToListAsync();

    }
}