using System;
using System.Threading.Tasks;
using Framework.Application;
using Framework.Application.Authentication;
using Framework.Application.Hashing;
using MarketPlace.ApplicationContract.AI.Account;
using MarketPlace.ApplicationContract.ViewModels.Account;
using MarketPlace.Domain.Entities.Account;
using MarketPlace.Domain.RI.Account;

namespace MarketPlace.Application.Account
{
    public class UserApplication : IUserApplication
    {
        private readonly IAuthHelper _authHelper;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public UserApplication(IAuthHelper authHelper, IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _authHelper = authHelper;
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<OperationResult> Register(RegisterUserVM command)
        {
            var result = new OperationResult();

            if (_userRepository.Exists(u => u.Mobile == command.Mobile))
                return result.Failed(ApplicationMessage.DuplicatedMobile);

            var mobileActivateCode = new Random().Next(100000, 999999).ToString();

            var password = _passwordHasher.Hash(command.Password);

            var user = new User(command.FirstName, command.LastName, null, null, false, command.Mobile,
                mobileActivateCode, false, password, null);

            await _userRepository.AddEntityAsync(user);
            await _userRepository.SaveChangesAsync();

            return result.Succeeded("ثبت نام شما با موفقیت انجام شد ");
        }

        public async Task<OperationResult> Login(LoginUserVM command)
        {
            var result = new OperationResult();

            var user = await _userRepository.GetUserBy(command.Mobile);

            if (user is null) return result.Failed("کاربری با این مشخصات یافت نشد");

            var passwordResult = _passwordHasher.Check(user.Password, command.Password);
            if (!passwordResult.Verified) return result.Failed("رمز عبور شما اشتباه است!");

            if (!user.IsMobileConfirmed) return result.Failed("حساب کاربری شما غیر فعال می باشد");

            var authHelperVM = new AuthViewModel(user.Id, $"{user.FirstName} {user.LastName}", user.Mobile, command.IsKeep);
            _authHelper.Signin(authHelperVM);

            return result.Succeeded();
        }
    }
}