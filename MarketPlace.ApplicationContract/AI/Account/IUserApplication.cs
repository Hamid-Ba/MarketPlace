using System.Threading.Tasks;
using Framework.Application;
using MarketPlace.ApplicationContract.ViewModels.Account;

namespace MarketPlace.ApplicationContract.AI.Account
{
    public interface IUserApplication
    {
        OperationResult Logout();
        Task<EditUserVM> GetDetailForEditBy(long id);
        Task<OperationResult> Edit(EditUserVM command);
        Task<OperationResult> Login(LoginUserVM command);
        Task<OperationResult> Register(RegisterUserVM command);
        Task<OperationResult> ForgotPassword(ForgotPasswordUserVM command);
        Task<OperationResult> ActiveUserAccount(ActiveMobileUserVM command);
        Task<OperationResult> RecoverPassword(RecoverPasswordUserVM command);
        Task<OperationResult> ChangePassword(long userId, ChangePasswordUserVM command);
    }
}