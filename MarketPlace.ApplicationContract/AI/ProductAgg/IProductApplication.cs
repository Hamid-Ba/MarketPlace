using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.Application;
using MarketPlace.ApplicationContract.ViewModels.ProductAgg;

namespace MarketPlace.ApplicationContract.AI.ProductAgg
{
    public interface IProductApplication
    {
        Task<OperationResult> Create(CreateProductVM command);
        Task<OperationResult> Edit(EditProductVM command);
        Task<EditProductVM> GetDetailForEditBy(long id);
        Task<IEnumerable<AdminProductVM>> GetAllForAdmin();
        Task<OperationResult> ConfirmOrDissConfirm(long id, bool isConfirm ,string reason);
    }
}
