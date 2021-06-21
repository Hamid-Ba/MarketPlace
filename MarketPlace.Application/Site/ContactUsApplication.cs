using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Application;
using MarketPlace.ApplicationContract.AI.Site;
using MarketPlace.ApplicationContract.ViewModels.Site;
using MarketPlace.Domain.Entities.Site;
using MarketPlace.Domain.RI.Account;

namespace MarketPlace.Application.Site
{
    public class ContactUsApplication : IContactUsApplication
    {
        private readonly IContactUsRepository _contactUsRepository;

        public ContactUsApplication(IContactUsRepository contactUsRepository) => _contactUsRepository = contactUsRepository;

        public async Task<OperationResult> SendMessage(CreateContactUsVM command, string ip, long userId)
        {
            var result = new OperationResult();

            try
            {
                var message = new ContactUs(command.FullName, command.Email, command.Subject, command.Message, ip, userId);

                await _contactUsRepository.AddEntityAsync(message);
                await _contactUsRepository.SaveChangesAsync();

                return result.Succeeded("پیام شما با موفقیت ارسال شد");
            }
            catch { return result.Failed("مشکلی پیش آمده است!"); }
        }
    }
}