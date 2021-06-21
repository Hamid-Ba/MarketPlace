using System;
using Framework.Domain;

namespace MarketPlace.Domain.Entities.Site
{
    public class ContactUs : EntityBase
    {
        public long UserId { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string Subject { get; private set; }
        public string Message { get; private set; }
        public string Ip { get; private set; }
        

        public ContactUs(string fullName, string email, string subject, string message, string ip, long userId)
        {
            FullName = fullName;
            Email = email;
            Subject = subject;
            Message = message;
            Ip = ip;
            UserId = userId;
            LastUpdateDate = DateTime.Now;
        }

        public void Delete()
        {
            IsDelete = true;
            DeletionDate = DateTime.Now;
        }
    }
}