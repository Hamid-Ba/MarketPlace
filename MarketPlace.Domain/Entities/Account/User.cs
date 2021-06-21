using System;
using System.Security.Cryptography;
using Framework.Domain;

namespace MarketPlace.Domain.Entities.Account
{
    public class User : EntityBase
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string EmailActivateCode { get; private set; }
        public bool IsEmailConfirmed { get; private set; }
        public string Mobile { get; private set; }
        public string MobileActivateCode { get; private set; }
        public bool IsMobileConfirmed { get; private set; }
        public string Password { get; private set; }
        public string Avatar { get; private set; }
        public bool IsBlocked { get; private set; }

        public User(string firstName, string lastName, string email, string emailActivateCode, bool isEmailConfirmed, string mobile,
            string mobileActivateCode, bool isMobileConfirmed, string password, string avatar)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            EmailActivateCode = emailActivateCode;
            IsEmailConfirmed = isEmailConfirmed;
            Mobile = mobile;
            MobileActivateCode = mobileActivateCode;
            IsMobileConfirmed = isMobileConfirmed;
            Password = password;
            Avatar = avatar;
            IsBlocked = false;
        }

        public void Edit(string firstName, string lastName, string email, string emailActivateCode, bool isEmailConfirmed, string mobile,
            string mobileActivateCode, bool isMobileConfirmed, string avatar)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            EmailActivateCode = emailActivateCode;
            IsEmailConfirmed = isEmailConfirmed;
            Mobile = mobile;
            MobileActivateCode = mobileActivateCode;
            IsMobileConfirmed = isMobileConfirmed;

            if (!string.IsNullOrEmpty(avatar))
                Avatar = avatar;

            LastUpdateDate = DateTime.Now;
        }

        public void ChangePassword(string newPassword) => Password = newPassword;

        public void ConfirmMobile() => IsMobileConfirmed = true;

        public void ReCodeMobileActivateCode(string newMobileActivateCode) => MobileActivateCode = newMobileActivateCode;

        public void BlockUser() => IsBlocked = true;

    }
}