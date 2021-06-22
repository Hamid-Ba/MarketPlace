using System.Threading.Tasks;
using Framework.Application;
using MarketPlace.ApplicationContract.AI.Site;
using MarketPlace.ApplicationContract.ViewModels.Site;
using MarketPlace.Domain.Entities.Site;
using MarketPlace.Domain.RI.Site;

namespace MarketPlace.Application.Site
{
    public class SiteSliderApplication : ISiteSliderApplication
    {
        private readonly ISiteSliderRepository _siteSliderRepository;

        public SiteSliderApplication(ISiteSliderRepository siteSliderRepository) => _siteSliderRepository = siteSliderRepository;

        public async Task<OperationResult> Create(CreateSiteSliderVM command)
        {
            var result = new OperationResult();
            try
            {
                var imageName = Uploader.ImageUploader(command.ImageFile, "Slide", null!);
                
                var slider = new SiteSlider(command.FirstHeader, command.SecondHeader, command.Description,
                    command.TextButton, command.Link, imageName, command.IsDisplay);

                await _siteSliderRepository.AddEntityAsync(slider);
                await _siteSliderRepository.SaveChangesAsync();

                return result.Succeeded();
            }
            catch { return result.Failed(ApplicationMessage.GoesWrong); }
        }
    }
}