using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Application;
using Framework.Application.Hashing;
using MarketPlace.ApplicationContract.AI.Account;
using MarketPlace.ApplicationContract.ViewModels.Account;
using MarketPlace.Domain.Entities.Account;
using MarketPlace.Domain.RI.Account;

namespace MarketPlace.Application.Account
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public UserApplication(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
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

            return result.Succeeded("ثبت نام شما با موفقیت انجام شد ، جهت تکمیل ثبت نام کد فعال سازی برای شما ارسال شد");
        }
    }
}
