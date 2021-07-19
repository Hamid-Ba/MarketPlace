using System.Linq;
using MarketPlace.Domain.Entities.Account;
using MarketPlace.Domain.Entities.Site;
using MarketPlace.Domain.Entities.StoreAgg;
using MarketPlace.Domain.Entities.StoreAgg.ProductAgg;
using MarketPlace.Domain.Entities.Tickets;
using MarketPlace.Infrastructure.EfCore.Mapping.Account;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.EfCore.Context
{
    public class MarketPlaceContext : DbContext
    {
        public MarketPlaceContext(DbContextOptions<MarketPlaceContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;

            var assembly = typeof(UserMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            modelBuilder.Entity<User>().HasQueryFilter(q => !q.IsDelete);
            modelBuilder.Entity<ContactUs>().HasQueryFilter(q => !q.IsDelete);
            modelBuilder.Entity<SiteSlider>().HasQueryFilter(q => !q.IsDelete);
            modelBuilder.Entity<SiteBanner>().HasQueryFilter(q => !q.IsDelete);
            modelBuilder.Entity<Ticket>().HasQueryFilter(q => !q.IsDelete);
            modelBuilder.Entity<Store>().HasQueryFilter(q => !q.IsDelete);
            modelBuilder.Entity<Product>().HasQueryFilter(q => !q.IsDelete);
            modelBuilder.Entity<Category>().HasQueryFilter(q => !q.IsDelete);
            modelBuilder.Entity<Product_Category>().HasQueryFilter(q => !q.IsDelete);
            modelBuilder.Entity<Picture>().HasQueryFilter(q => !q.IsDelete);
            
        }

        #region Account

        public DbSet<User> Users { get; set; }

        #endregion

        #region Site

        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<SiteSlider> SiteSliders { get; set; }
        public DbSet<SiteBanner> SiteBanners { get; set; }

        #endregion

        #region Ticket

        public DbSet<Ticket> Tickets { get; set; }

        #endregion

        #region Store

        public DbSet<Store> Stores { get; set; }

        #region Products

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product_Category> ProductCategories { get; set; }
        public DbSet<Picture> Pictures { get; set; }

        #endregion

        #endregion

    }
}