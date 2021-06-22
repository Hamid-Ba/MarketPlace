using System.Threading.Tasks;
using Framework.Application;
using MarketPlace.ApplicationContract.ViewModels.Site;

namespace MarketPlace.ApplicationContract.AI.Site
{
    public interface ISiteBannerApplication
    {
        Task<OperationResult> Create(CreateSiteBannerVM command);
    }
}