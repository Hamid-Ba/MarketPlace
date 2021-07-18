using System.Collections.Generic;
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

            if (command.ImageFile is null) return result.Failed("تصویر محصول را آپلود کنید");
            if (!command.ImageFile.IsImage()) return result.Failed("عکس وارد کن دیوث");
            if (string.IsNullOrWhiteSpace(command.Description)) return result.Failed("توضیحات اصلی را پر کنید");
            if (command.CategoriesId is null) return result.Failed("دسته بندی را انتخاب کنید");

            var path = $"Products/{command.StoreId}";
            var imageName = Uploader.ImageUploader(command.ImageFile, path, null!);

            var product = new Domain.Entities.StoreAgg.ProductAgg.Product(command.StoreId, command.Title, imageName,
                command.Price, command.ShortDescription,
                command.Description, "", command.IsActive, ProductAcceptanceState.UnderProgress);

            await _productRepository.AddEntityAsync(product);
            await _productRepository.SaveChangesAsync();

            return await _productCategoryApplication.AddCategoriesToProduct(product.Id, command.CategoriesId);
        }

        public async Task<OperationResult> Edit(EditProductVM command)
        {
            OperationResult result = new();

            if (!await _productRepository.IsProductBelongToStore(command.Id, command.StoreId))
                return result.Failed("شما دسترسی به محصول بقیه ندارید");

            var product = await _productRepository.GetEntityByIdAsync(command.Id);
            if (product is null) return result.Failed(ApplicationMessage.NotExist);

            if (command.ImageFile != null)
                if (!command.ImageFile.IsImage()) return result.Failed("عکس وارد کن دیوث");

            if (string.IsNullOrWhiteSpace(command.Description)) return result.Failed("توضیحات اصلی را پر کنید");
            if (command.CategoriesId is null) return result.Failed("دسته بندی را انتخاب کنید");

            var path = $"Products/{command.StoreId}";
            var imageName = Uploader.ImageUploader(command.ImageFile, path, product.ImageName);

            product.Edit(command.Title, imageName, command.Price, command.ShortDescription, command.Description, command.IsActive);
            product.SetProductState(ProductAcceptanceState.UnderProgress, "");

            return await _productCategoryApplication.EditProductCategories(product.Id, command.CategoriesId);
        }

        public async Task<EditProductVM> GetDetailForEditBy(long id) => await _productRepository.GetDetailForEditBy(id);

        public async Task<IEnumerable<AdminProductVM>> GetAllForAdmin() => await _productRepository.GetAllForAdmin();

        public async Task<OperationResult> ConfirmOrDissConfirm(long id, bool isConfirm, string reason)
        {
            OperationResult result = new();

            var product = await _productRepository.GetEntityByIdAsync(id);
            if (product is null) return result.Failed(ApplicationMessage.NotExist);

            product.SetProductState(isConfirm ? ProductAcceptanceState.Accepted : ProductAcceptanceState.Rejected, reason);
            await _productRepository.SaveChangesAsync();

            return result.Succeeded();
        }
    }
}