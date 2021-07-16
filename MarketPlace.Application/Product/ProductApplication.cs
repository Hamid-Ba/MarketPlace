using System.Threading.Tasks;
using Framework.Application;
using MarketPlace.ApplicationContract.AI.ProductAgg;
using MarketPlace.ApplicationContract.AI.ProductCategoryAgg;
using MarketPlace.ApplicationContract.ViewModels.ProductAgg;
using MarketPlace.Domain.RI.StoreAgg.ProductAgg;

namespace MarketPlace.Application.Product
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductCategoryApplication _productCategoryApplication;

        public ProductApplication(IProductRepository productRepository, IProductCategoryApplication productCategoryApplication)
        {
            _productRepository = productRepository;
            _productCategoryApplication = productCategoryApplication;
        }

        public async Task<OperationResult> Create(CreateProductVM command)
        {
            OperationResult result = new();

            if (!command.ImageFile.IsImage()) return result.Failed("عکس وارد کن دیوث");
            if (string.IsNullOrWhiteSpace(command.Description)) return result.Failed("توضیحات اصلی را پر کنید");

            var path = $"Products/{command.StoreId}";
            var imageName = Uploader.ImageUploader(command.ImageFile, path, null!);

            var product = new Domain.Entities.StoreAgg.ProductAgg.Product(command.StoreId, command.Title, imageName,
                command.Price, command.ShortDescription,
                command.Description, "", command.IsActive, ProductAcceptanceState.UnderProgress);

            await _productRepository.AddEntityAsync(product);
            await _productRepository.SaveChangesAsync();

            return await _productCategoryApplication.AddCategoriesToProduct(product.Id, command.CategoriesId);
        }
    }
}
