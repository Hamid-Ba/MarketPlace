using System.Threading.Tasks;
using Framework.Application;

namespace MarketPlace.ApplicationContract.AI.ProductCategoryAgg
{
    public interface IProductCategoryApplication
    {
        Task<OperationResult> AddCategoriesToProduct(long productId, long[] categoriesId);
        Task<OperationResult> EditProductCategories(long productId, long[] categoriesId);
    }
}
