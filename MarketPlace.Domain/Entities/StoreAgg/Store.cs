using System;
using Framework.Application;
using Framework.Domain;
using MarketPlace.Domain.Entities.Account;

namespace MarketPlace.Domain.Entities.StoreAgg
{
    public class Store : EntityBase
    {
        public long UserId { get; private set; }
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public string MobileNumber { get; private set; }
        public StoreStatus Status { get; private set; }
        public string AdminDescription { get; private set; }
        public string Description { get; private set; }
        public string Address { get; private set; }
        public string StoreGivenStatusReason { get; set; }

        public User User { get; private set; }

        public Store(long userId, string name, string mobileNumber, StoreStatus status, string address)
        {
            UserId = userId;
            Name = name;
            MobileNumber = mobileNumber;
            Status = status;
            Address = address;
            StoreGivenStatusReason = "";
        }

        public void Edit(string name, string phoneNumber, string mobileNumber, string adminDescription, string description, string address,
            string storeGivenStatusReason)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            MobileNumber = mobileNumber;
            AdminDescription = adminDescription;
            Description = description;
            Address = address;
            StoreGivenStatusReason = storeGivenStatusReason;
            LastUpdateDate = DateTime.Now;
        }

        public void ChangeStatus(StoreStatus status, string reason)
        {
            Status = status;

            if (!string.IsNullOrWhiteSpace(reason)) StoreGivenStatusReason = reason;

            LastUpdateDate = DateTime.Now;
        }

        public void Delete()
        {
            IsDelete = true;
            DeletionDate = DateTime.Now;
        }
    }
}