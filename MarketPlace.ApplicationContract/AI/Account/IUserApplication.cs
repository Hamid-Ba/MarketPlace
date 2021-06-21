using System.Threading.Tasks;
using Framework.Application;
using MarketPlace.ApplicationContract.ViewModels.Account;

namespace MarketPlace.ApplicationContract.AI.Account
{
    public interface IUserApplication
    {
        Task<OperationResult> Register(RegisterUserVM command);
        Task<OperationResult> Login(LoginUserVM command);
        Task<OperationResult> ForgotPassword(ForgotPasswordUserVM command);
        Task<OperationResult> RecoverPassword(RecoverPasswordUserVM command);
        Task<OperationResult> ActiveUserAccount(ActiveMobileUserVM command);
        OperationResult Logout();
    }
}
