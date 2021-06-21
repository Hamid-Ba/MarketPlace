using System.Threading.Tasks;
using Framework.Application;
using MarketPlace.ApplicationContract.ViewModels.Site;

namespace MarketPlace.ApplicationContract.AI.Site
{
    public interface IContactUsApplication
    {
        Task<OperationResult> SendMessage(CreateContactUsVM command, string ip, long userId);
    }
}
