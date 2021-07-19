using System.Threading.Tasks;
using Framework.Application;
using MarketPlace.ApplicationContract.AI.PictureAgg;
using MarketPlace.ApplicationContract.ViewModels.PictureAgg;
using MarketPlace.Domain.RI.StoreAgg.ProductAgg;

namespace MarketPlace.Application.Picture
{
    public class PictureApplication : IPictureApplication
    {
        private readonly IPictureRepository _pictureRepository;
        private readonly IProductRepository _productRepository;

        public PictureApplication(IPictureRepository pictureRepository, IProductRepository productRepository)
        {
            _pictureRepository = pictureRepository;
            _productRepository = productRepository;
        }

        public async Task<OperationResult> Create(CreatePictureVM command)
        {
            OperationResult result = new();

            //Check Ownership
            if (!await _productRepository.IsProductBelongToUser(command.ProductId, command.UserId))
                return result.Failed(ApplicationMessage.DoNotAccessToOtherStore);

            if (command.ImageFile is null) return result.Failed(ApplicationMessage.UploadImage);
            if (!command.ImageFile.IsImage()) return result.Failed(ApplicationMessage.WrongFormat);
            if (_pictureRepository.Exists(p => p.Priority == command.Priority && p.ProductId == command.ProductId))
                return result.Failed("همچین تصویری با این اولویت وجود دارد");

            var path = $"Picture/{command.ProductId}";
            var imageName = Uploader.ImageUploader(command.ImageFile, path, null!);

            var picture =
                new Domain.Entities.StoreAgg.ProductAgg.Picture(command.ProductId, imageName, command.Priority);

            await _pictureRepository.AddEntityAsync(picture);
            await _pictureRepository.SaveChangesAsync();

            return result.Succeeded();
        }

        public async Task<OperationResult> Edit(EditPictureVM command)
        {
            OperationResult result = new();

            //Check Ownership
            if (!await _productRepository.IsProductBelongToUser(command.ProductId, command.UserId))
                return result.Failed(ApplicationMessage.DoNotAccessToOtherStore);

            if (command.ImageFile is null) return result.Failed(ApplicationMessage.UploadImage);
            if (!command.ImageFile.IsImage()) return result.Failed(ApplicationMessage.WrongFormat);

            var picture = await _pictureRepository.GetEntityByIdAsync(command.Id);
            if (picture is null) return result.Failed(ApplicationMessage.NotExist);
            if (_pictureRepository.Exists(p => p.Priority == command.Priority && p.ProductId == command.ProductId
                                                                              && p.Id != command.Id))
                return result.Failed("همچین تصویری با این اولویت وجود دارد");

            var path = $"Picture/{command.ProductId}";
            var imageName = Uploader.ImageUploader(command.ImageFile, path, picture.ImageName);

            picture.Edit(imageName, command.Priority);
            await _pictureRepository.SaveChangesAsync();

            return result.Succeeded();
        }

        public async Task<EditPictureVM> GetDetailForEditBy(long id, long productId) => await _pictureRepository.GetDetailForEditBy(id, productId);

    }
}