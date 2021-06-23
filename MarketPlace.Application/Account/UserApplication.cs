using System;
using System.Threading.Tasks;
using Framework.Application;
using Framework.Application.Authentication;
using Framework.Application.Hashing;
using Framework.Application.SMS;
using MarketPlace.ApplicationContract.AI.Account;
using MarketPlace.ApplicationContract.ViewModels.Account;
using MarketPlace.Domain.Entities.Account;
using MarketPlace.Domain.RI.Account;

namespace MarketPlace.Application.Account
{
    public class UserApplication : IUserApplication
    {
        private readonly IAuthHelper _authHelper;
        private readonly ISmsService _smsService;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public UserApplication(IAuthHelper authHelper, ISmsService smsService, IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _authHelper = authHelper;
            _smsService = smsService;
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

            var message = $"{user.FirstName} {user.LastName} عزیز ، کد فعال سازی حساب شما : {user.MobileActivateCode}";
            _smsService.SendSms(command.Mobile, message);

            return result.Succeeded("ثبت نام شما با موفقیت انجام شد ");
        }

        public async Task<OperationResult> Login(LoginUserVM command)
        {
            var result = new OperationResult();

            var user = await _userRepository.GetUserBy(command.Mobile);

            if (user is null) return result.Failed(ApplicationMessage.UserNotExist);

            var passwordResult = _passwordHasher.Check(user.Password, command.Password);
            if (!passwordResult.Verified) return result.Failed("رمز عبور شما اشتباه است!");

            if (!user.IsMobileConfirmed) return result.Failed("حساب کاربری شما غیر فعال می باشد");

            var authHelperVM = new AuthViewModel(user.Id, $"{user.FirstName} {user.LastName}", user.Mobile, command.IsKeep);
            _authHelper.Signin(authHelperVM);

            return result.Succeeded("با موفقیت وارد شدید");
        }

        public async Task<OperationResult> ForgotPassword(ForgotPasswordUserVM command)
        {
            var result = new OperationResult();

            var user = await _userRepository.GetUserBy(command.Mobile);

            if (user is null) return result.Failed(ApplicationMessage.UserNotExist);

            user.ReCodeMobileActivateCode(new Random().Next(100000, 999999).ToString());
            user.LastUpdateDate = DateTime.Now;
            await _userRepository.SaveChangesAsync();

            var message =
                $"{user.FirstName} {user.LastName} عزیز ، جهت بازیابی رمز عبور خود کد زیر را وارد نمایید : {user.MobileActivateCode}";
            _smsService.SendSms(user.Mobile,message);

            return result.Succeeded("کد فعال سازی برای شما ارسال شد ، جهت ادامه پردازش آن را وارد نمایید");
        }

        public async Task<OperationResult> RecoverPassword(RecoverPasswordUserVM command)
        {
            var result = new OperationResult();

            var user = await _userRepository.GetUserBy(command.Mobile);

            if (user is null) return result.Failed(ApplicationMessage.UserNotExist);

            if (command.MobileActivateCode != user.MobileActivateCode)
                return result.Failed("کد وارد شده صحیح نمی باشد!");

            var purePassword = Guid.NewGuid().ToString().Substring(0, 6);
            var newPassword = _passwordHasher.Hash(purePassword);

            user.ChangePassword(newPassword);
            user.ReCodeMobileActivateCode(new Random().Next(100000, 999999).ToString());
            user.LastUpdateDate = DateTime.Now;

            var message = $"رمز عبور جدید شما : {purePassword} می باشد . لطفا بعد از ورود به حساب خود آن را تغییر دهید";
            _smsService.SendSms(user.Mobile,message);

            await _userRepository.SaveChangesAsync();

            return result.Succeeded("رمز عبور شما با موفقیت تغییر کرد");
        }

        public async Task<OperationResult> ChangePassword(long userId, ChangePasswordUserVM command)
        {
            var result = new OperationResult();

            var user = await _userRepository.GetEntityByIdAsync(userId);
            if (user is null) return result.Failed(ApplicationMessage.UserNotExist);

            var passwordVerified = _passwordHasher.Check(user.Password, command.CurrentPassword);
            if (!passwordVerified.Verified) return result.Failed("رمز عبور شما اشتباه می باشد");
            
            var newPasswordVerified = _passwordHasher.Check(user.Password, command.NewPassword);
            if (newPasswordVerified.Verified) return result.Failed("لطفا رمز عبور جدیدی را مدنظر بگیرید");

            var newPassword = _passwordHasher.Hash(command.NewPassword);
            user.ChangePassword(newPassword);
            user.LastUpdateDate = DateTime.Now;

            await _userRepository.SaveChangesAsync();

            return Logout();
        }

        public async Task<OperationResult> ActiveUserAccount(ActiveMobileUserVM command)
        {
            var result = new OperationResult();

            var user = await _userRepository.GetUserBy(command.Mobile);
            if (user is null) return result.Failed(ApplicationMessage.UserNotExist);

            if (command.MobileActivateCode != user.MobileActivateCode)
                return result.Failed("کد وارد شده صحیح نمی باشد!");

            var mobileActivateCode = new Random().Next(100000, 999999).ToString();
            user.ReCodeMobileActivateCode(mobileActivateCode);
            user.ConfirmMobile();
            user.LastUpdateDate = DateTime.Now;

            await _userRepository.SaveChangesAsync();

            return result.Succeeded("حساب شما با موفقیت فعال شد");
        }

        public OperationResult Logout()
        {
            var result = new OperationResult();

            try
            {
                _authHelper.SignOut();
                return result.Succeeded("با موفقیت خارج شدید");
            }
            catch
            {
                return result.Failed("خروج با مشکل مواجه شد");
            }
        }
    }
}