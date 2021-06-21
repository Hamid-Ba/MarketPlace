using System.Linq;
using MarketPlace.Domain.Entities.Account;
using MarketPlace.Domain.Entities.Site;
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
                relationship.DeleteBehavior = DeleteBehavior.Cascade;

            var assembly = typeof(UserMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            modelBuilder.Entity<User>().HasQueryFilter(q => !q.IsDelete);
            modelBuilder.Entity<ContactUs>().HasQueryFilter(q => !q.IsDelete);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
    }
}