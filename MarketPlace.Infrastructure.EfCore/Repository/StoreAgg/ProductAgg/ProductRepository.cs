using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Infrastructure;
using MarketPlace.ApplicationContract.ViewModels.ProductAgg;
using MarketPlace.Domain.Entities.StoreAgg.ProductAgg;
using MarketPlace.Domain.RI.StoreAgg.ProductAgg;
using MarketPlace.Infrastructure.EfCore.Context;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.EfCore.Repository.StoreAgg.ProductAgg
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly MarketPlaceContext _context;

        public ProductRepository(MarketPlaceContext context) : base(context) => _context = context;

        public async Task<EditProductVM> GetDetailForEditBy(long id) => await _context.Products
            .Include(c => c.Categories).Select(p => new EditProductVM()
            {
                Id = p.Id,
                StoreId = p.StoreId,
                CategoriesId = p.Categories.Where(c => c.ProductId == p.Id).Select(c => c.CategoryId).ToArray(),
                Description = p.Description,
                IsActive = p.IsActive,
                Price = p.Price,
                ShortDescription = p.ShortDescription,
                Title = p.Title
            }).FirstOrDefaultAsync(p => p.Id == id);

        public async Task<IEnumerable<AdminProductVM>> GetAllForAdmin() => await _context.Products
            .Include(u => u.Store).ThenInclude(u => u.User)
            .Include(c => c.Categories).ThenInclude(c => c.Category)
            .Select(p => new AdminProductVM()
            {
                Id = p.Id,
                StoreName = p.Store.Name,
                OwnerName = $"{p.Store.User.FirstName} {p.Store.User.LastName}",
                Price = p.Price,
                Title = p.Title,
                State = p.ProductAcceptanceState,
                CategoriesName = p.Categories.Where(c => c.ProductId == p.Id).Select(c => c.Category.Name).ToArray()
            }).AsNoTracking().ToListAsync();
    }
}