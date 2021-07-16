using MarketPlace.Application.Account;
using MarketPlace.Application.Category;
using MarketPlace.Application.Product;
using MarketPlace.Application.ProductCategory;
using MarketPlace.Application.Site;
using MarketPlace.Application.Store;
using MarketPlace.Application.Tickets;
using MarketPlace.ApplicationContract.AI.Account;
using MarketPlace.ApplicationContract.AI.CategoryAgg;
using MarketPlace.ApplicationContract.AI.ProductAgg;
using MarketPlace.ApplicationContract.AI.ProductCategoryAgg;
using MarketPlace.ApplicationContract.AI.Site;
using MarketPlace.ApplicationContract.AI.StoreAgg;
using MarketPlace.ApplicationContract.AI.Tickets;
using MarketPlace.Domain.RI.Account;
using MarketPlace.Domain.RI.Site;
using MarketPlace.Domain.RI.StoreAgg;
using MarketPlace.Domain.RI.StoreAgg.ProductAgg;
using MarketPlace.Domain.RI.Tickets;
using MarketPlace.Infrastructure.EfCore.Context;
using MarketPlace.Infrastructure.EfCore.Repository.Account;
using MarketPlace.Infrastructure.EfCore.Repository.Site;
using MarketPlace.Infrastructure.EfCore.Repository.StoreAgg;
using MarketPlace.Infrastructure.EfCore.Repository.StoreAgg.ProductAgg;
using MarketPlace.Infrastructure.EfCore.Repository.Tickets;
using MarketPlace.Query.Contract.Category;
using MarketPlace.Query.Contract.Product;
using MarketPlace.Query.Contract.Site.SiteBanner;
using MarketPlace.Query.Contract.Site.SiteSlider;
using MarketPlace.Query.Contract.Store;
using MarketPlace.Query.Contract.Tickets;
using MarketPlace.Query.Query.Category;
using MarketPlace.Query.Query.Product;
using MarketPlace.Query.Query.Site.SiteBanner;
using MarketPlace.Query.Query.Site.SiteSlider;
using MarketPlace.Query.Query.Store;
using MarketPlace.Query.Query.Tickets;
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

            #region Ticket

            services.AddTransient<ITicketRepository, TicketRepository>();
            services.AddTransient<ITicketApplication, TicketApplication>();

            #endregion

            #region Store

            services.AddTransient<IStoreRepository, StoreRepository>();
            services.AddTransient<IStoreApplication, StoreApplication>();

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductApplication, ProductApplication>();

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICategoryApplication, CategoryApplication>();


            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            #endregion

            #region Queries

            services.AddTransient<ISiteSliderQuery, SiteSliderQuery>();

            services.AddTransient<ISiteBannerQuery, SiteBannerQuery>();

            services.AddTransient<ITicketQuery, TicketQuery>();

            services.AddTransient<IStoreQuery, StoreQuery>();

            services.AddTransient<IProductQuery, ProductQuery>();

            services.AddTransient<ICategoryQuery, CategoryQuery>();
            #endregion
        }
    }
}