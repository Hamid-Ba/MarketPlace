using System.Threading.Tasks;
using Framework.Application;
using MarketPlace.ApplicationContract.ViewModels.ProductAgg;

namespace MarketPlace.ApplicationContract.AI.ProductAgg
{
    public interface IProductApplication
    {
        Task<OperationResult> Create(CreateProductVM command);
    }
}
