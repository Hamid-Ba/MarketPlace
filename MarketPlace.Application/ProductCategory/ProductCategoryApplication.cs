using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.Application;
using MarketPlace.ApplicationContract.AI.ProductCategoryAgg;
using MarketPlace.Domain.Entities.StoreAgg.ProductAgg;
using MarketPlace.Domain.RI.StoreAgg.ProductAgg;

namespace MarketPlace.Application.ProductCategory
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository) => _productCategoryRepository = productCategoryRepository;

        public async Task<OperationResult> AddCategoriesToProduct(long productId, long[] categoriesId)
        {
            OperationResult result = new();

            try
            {
                List<Product_Category> productCategories = new();
                foreach (var catId in categoriesId)
                    productCategories.Add(new Product_Category(productId, catId));

                await _productCategoryRepository.AddRangeOfEntitiesAsync(productCategories);
                await _productCategoryRepository.SaveChangesAsync();

                return result.Succeeded();
            }
            catch { return result.Failed(ApplicationMessage.GoesWrong); }
        }
    }
}
