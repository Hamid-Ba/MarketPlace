using MarketPlace.Infrastructure.EfCore.Context;
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
        }
    }
}
