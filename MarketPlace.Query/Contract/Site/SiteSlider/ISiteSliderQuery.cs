using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketPlace.Query.Contract.Site.SiteSlider
{
    public interface ISiteSliderQuery
    {
        Task<IEnumerable<SiteSliderQueryVM>> GetAllSliderForMainPage();
    }
}