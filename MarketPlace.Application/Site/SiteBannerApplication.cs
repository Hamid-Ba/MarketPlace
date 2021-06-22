using System.Threading.Tasks;
using Framework.Application;
using MarketPlace.ApplicationContract.AI.Site;
using MarketPlace.ApplicationContract.ViewModels.Site;
using MarketPlace.Domain.Entities.Site;
using MarketPlace.Domain.RI.Site;

namespace MarketPlace.Application.Site
{
    public class SiteBannerApplication : ISiteBannerApplication
    {
        private readonly ISiteBannerRepository _bannerRepository;

        public SiteBannerApplication(ISiteBannerRepository bannerRepository) => _bannerRepository = bannerRepository;

        public async Task<OperationResult> Create(CreateSiteBannerVM command)
        {
            var result = new OperationResult();

            try
            {
                var imageName = Uploader.ImageUploader(command.ImageFile, "bg", null!);

                var banner = new SiteBanner(imageName, command.ColSize, command.Url, command.Position);

                await _bannerRepository.AddEntityAsync(banner);
                await _bannerRepository.SaveChangesAsync();

                return result.Succeeded();
            }
            catch { return result.Failed(ApplicationMessage.GoesWrong); }
        }
    }
}