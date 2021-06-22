using System.Threading.Tasks;
using Framework.Application;
using MarketPlace.ApplicationContract.ViewModels.Site;

namespace MarketPlace.ApplicationContract.AI.Site
{
    public interface ISiteSliderApplication
    {
        Task<OperationResult> Create(CreateSiteSliderVM command);
    }
}