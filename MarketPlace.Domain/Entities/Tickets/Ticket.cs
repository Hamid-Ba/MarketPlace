using System;
using System.Collections.Generic;
using Framework.Application.TicketComponents;
using Framework.Domain;
using MarketPlace.Domain.Entities.Account;

namespace MarketPlace.Domain.Entities.Tickets
{
    public class Ticket : EntityBase
    {
        public long UserId { get; private set; }
        public string Title { get; private set; }
        public TicketSection Section { get; private set; }
        public TicketStatus Status { get; private set; }
        public TicketNecessary Necessary { get; private set; }
        public bool IsReadByOwner { get; private set; }
        public bool IsReadByAdmin { get; private set; }

        public User User { get; private set; }
        public List<TicketMessage> Messages { get; private set; }

        public Ticket(long userId, string title, TicketSection section, TicketStatus status, TicketNecessary necessary, bool isReadByOwner, bool isReadByAdmin)
        {
            UserId = userId;
            Title = title;
            Section = section;
            Status = status;
            Necessary = necessary;
            IsReadByOwner = isReadByOwner;
            IsReadByAdmin = isReadByAdmin;
            Messages = new List<TicketMessage>();
        }

        public void Delete()
        {
            IsDelete = true;
            DeletionDate = DateTime.Now;
        }

        public void WhoReadTicket(bool isItUser, bool isItAdmin)
        {
            IsReadByAdmin = isItAdmin;
            IsReadByOwner = isItUser;
            LastUpdateDate = DateTime.Now;
        }

        public void AddMessage(TicketMessage message)
        {
            if (!string.IsNullOrEmpty(message.Text)) Messages.Add(message);
        }

    }
}