using MarketPlace.Application.Account;
using MarketPlace.Application.Site;
using MarketPlace.ApplicationContract.AI.Account;
using MarketPlace.ApplicationContract.AI.Site;
using MarketPlace.Domain.RI.Account;
using MarketPlace.Domain.RI.Site;
using MarketPlace.Infrastructure.EfCore.Context;
using MarketPlace.Infrastructure.EfCore.Repository.Account;
using MarketPlace.Infrastructure.EfCore.Repository.Site;
using MarketPlace.Query.Contract.Site.SiteBanner;
using MarketPlace.Query.Contract.Site.SiteSlider;
using MarketPlace.Query.Query.Site.SiteBanner;
using MarketPlace.Query.Query.Site.SiteSlider;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MarketPlace.Infrastructure.Configuration
{
    public class MarketPlaceBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            #region ConfigureContext

            services.AddDbContext<MarketPlaceContext>(option => option.UseSqlServer(connectionString));

            #endregion

            #region Account

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserApplication, UserApplication>();

            #endregion

            #region Site

            services.AddTransient<IContactUsRepository, ContactUsRepository>();
            services.AddTransient<IContactUsApplication, ContactUsApplication>();

            services.AddTransient<ISiteSliderRepository, SiteSliderRepository>();
            services.AddTransient<ISiteSliderApplication, SiteSliderApplication>();

            services.AddTransient<ISiteBannerRepository, SiteBannerRepository>();
            services.AddTransient<ISiteBannerApplication, SiteBannerApplication>();
            #endregion

            #region Queries

            services.AddTransient<ISiteSliderQuery, SiteSliderQuery>();

            services.AddTransient<ISiteBannerQuery, SiteBannerQuery>();

            #endregion
        }
    }
}