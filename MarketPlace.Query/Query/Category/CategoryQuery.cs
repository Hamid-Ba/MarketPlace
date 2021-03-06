using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketPlace.Infrastructure.EfCore.Context;
using MarketPlace.Query.Contract.Category;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Query.Query.Category
{
    public class CategoryQuery : ICategoryQuery
    {
        private readonly MarketPlaceContext _context;

        public CategoryQuery(MarketPlaceContext context) => _context = context;

        public async Task<IEnumerable<CategoryQueryVM>> GetCategories()
        {
            var result = await _context.Categories.Include(c => c.SubCategories).ThenInclude(c => c.SubCategories)
                   .Where(c => c.ParentId == null).Select(c => new CategoryQueryVM()
                   {
                       Id = c.Id,
                       Name = c.Name,
                       UrlName = c.UrlName,
                       Categories = MapCategories(c.SubCategories)
                   }).ToListAsync();

            return result;
        }

        private static List<CategoryQueryVM> MapCategories(List<Domain.Entities.StoreAgg.ProductAgg.Category> categories)
        {
            var result = categories?.
                Select(c => new CategoryQueryVM()
                {
                    Id = c.Id,
                    ParentId = c.ParentId,
                    Name = c.Name,
                    UrlName = c.UrlName,
                    Categories = MapCategories(c.SubCategories)
                }).ToList();

            return result;
        }

    }
}