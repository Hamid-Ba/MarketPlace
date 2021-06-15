using MarketPlace.Application.Account;
using MarketPlace.ApplicationContract.AI.Account;
using MarketPlace.Domain.RI.Account;
using MarketPlace.Infrastructure.EfCore.Context;
using MarketPlace.Infrastructure.EfCore.Repository.Account;
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
        }
    }
}
