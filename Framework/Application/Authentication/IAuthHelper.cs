using System.Collections.Generic;

namespace Framework.Application.Authentication
{
    public interface IAuthHelper
    {
        void SignOut();
        void Signin(AuthViewModel account);
    }
}
