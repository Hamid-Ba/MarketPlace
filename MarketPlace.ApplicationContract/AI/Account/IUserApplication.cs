using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Application;
using MarketPlace.ApplicationContract.ViewModels.Account;

namespace MarketPlace.ApplicationContract.AI.Account
{
    public interface IUserApplication
    {
        Task<OperationResult> Register(RegisterUserVM command);
    }
}
