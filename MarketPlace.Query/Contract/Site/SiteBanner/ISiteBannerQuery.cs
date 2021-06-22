using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.Application;

namespace MarketPlace.Query.Contract.Site.SiteBanner
{
    public interface ISiteBannerQuery
    {
        Task<IEnumerable<SiteBannerQueryVM>> GetBannersBy(IEnumerable<BannerPosition> positions);
    }
}