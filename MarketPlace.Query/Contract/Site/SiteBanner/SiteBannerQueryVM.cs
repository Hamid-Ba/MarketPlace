using Framework.Application;

namespace MarketPlace.Query.Contract.Site.SiteBanner
{
    public class SiteBannerQueryVM
    {
        public string ImageName { get;  set; }
        public string ColSize { get;  set; }
        public string Url { get;  set; }
        public BannerPosition Position { get;  set; }
    }
}