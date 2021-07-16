using System.Collections.Generic;
using System.Threading.Tasks;
using MarketPlace.ApplicationContract.AI.CategoryAgg;
using MarketPlace.Domain.RI.StoreAgg.ProductAgg;

namespace MarketPlace.Application.Category
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryApplication(ICategoryRepository categoryRepository) => _categoryRepository = categoryRepository;
    }
}